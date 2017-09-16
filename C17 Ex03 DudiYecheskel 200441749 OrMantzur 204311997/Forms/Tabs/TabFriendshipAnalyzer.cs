/*
 * C17_Ex01: TabFriendshipAnalyzer.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Threading;
using System.Windows.Forms;
using C17_Ex01_Dudi_200441749_Or_204311997.Adapter;
using C17_Ex01_Dudi_200441749_Or_204311997.Properties;
using C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies;
using FacebookWrapper.ObjectModel;


namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs
{
    public partial class TabFriendshipAnalyzer : UserControl
    {
        private FriendshipAnalyzer m_FriendshipAnalyzer;
        private Action FriendSelectionChanged;

        public TabFriendshipAnalyzer()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs i_Args)
        {
            base.OnHandleCreated(i_Args);
            initializeTab();
        }

        private void initializeTab()
        {
            FriendSelectionChanged += OnFriendSelectionChanged;
            setEventHandlers();
            m_FriendshipAnalyzer = new FriendshipAnalyzer();
            flowLayoutPanelExtenderForFacebookFriends.Update(friendshipAnalyzerFriendsDockPhoto_MouseClick);
        }

        protected virtual void OnFriendSelectionChanged()
        {
            User selectedFriend = m_FriendshipAnalyzer.Friend;

            panelGeneralInfo.Visible = false;
            clearAllTreeViews();
            listBoxPhotosCommentedOn.Items.Clear();
            pictureBoxMostRecentTaggedTogether.Image = Resources.Picture_not_found;
            pictureBoxMostRecentTaggedTogether.Tag = null;
            labelFirstName.Text = selectedFriend.FirstName;
            labelLastName.Text = selectedFriend.LastName;
            labelNumLikes.Text = string.Format("Number of times {0} liked my photos: {1}", selectedFriend.FirstName, "[no data fetched]");
            labelNumComments.Text = string.Format("Number of times {0} commented on my photos: {1}", selectedFriend.FirstName, "[no data fetched]");
            buttonFetchMyPhotosFriendIsIn.Text = string.Format("Fetch photos of mine {0} is in", selectedFriend.FirstName);
            buttonFetchPhotosOfFriendIAmTaggedIn.Text = string.Format("Fetch {0}'s Photos I am Tagged in", selectedFriend.FirstName);
            panelGeneralInfo.Visible = true;
        }

        private void friendshipAnalyzerFetchGeneralData()
        {
            buttonFetchGeneralData.Enabled = false;
            FormProgressBar formProgressBar =
                new FormProgressBar(2 * m_FriendshipAnalyzer.AllPhotos.Count, "statistics") { CancelEnabled = true };

            formProgressBar.Show();
            getMostRecentPhotoTogether();
            Thread getLikesThread = FacebookApplication.StartThread(
                () => m_FriendshipAnalyzer.CountNumberOfPhotosFriendLiked(() => formProgressBar.ProgressValue++));
            Thread getCommentsThread = FacebookApplication.StartThread(
                () => m_FriendshipAnalyzer.CountNumberOfPhotosFriendCommented(() => formProgressBar.ProgressValue++));
            FriendSelectionChanged += () => formProgressBar.Close();
            formProgressBar.Closing += (i_Sender, i_Args) =>
            {
                FriendSelectionChanged -= () => formProgressBar.Close();
                if (formProgressBar.DialogResult == DialogResult.Cancel)
                {
                    getCommentsThread.Abort();
                    getLikesThread.Abort();
                }

                buttonFetchGeneralData.Enabled = true;
            };
            m_FriendshipAnalyzer.FinishedFetchingLikesAndComments += () =>
            {
                finishedFetchingLikesAndComments();
                formProgressBar.Close();
            };
        }

        private void finishedFetchingLikesAndComments()
        {
            if (!IsDisposed)
            {
                panelGeneralInfo.Invoke(
                    new Action(() =>
                    {
                        labelNumLikes.Text = string.Format(
"Number of times {0} liked my photos: {1}",
m_FriendshipAnalyzer.Friend.FirstName,
m_FriendshipAnalyzer.PhotosFriendLiked.Count);
                        labelNumComments.Text = string.Format(
"Number of times {0} commented on my photos: {1}",
m_FriendshipAnalyzer.Friend.FirstName,
m_FriendshipAnalyzer.CommentsByFriend.Count);
                        updateCommentsListBox();
                    }));
            }
        }

        private void fetchPhotosTaggedTogether()
        {
            IFacebookCollection<Photo> photosTaggedInAdapter = new FacebookCollectionAdapter<Photo>(eFacebookCollectionType.PhotosTaggedIn);
            FacebookObjectCollection<FacebookObject> boxPhotosTaggedIn = photosTaggedInAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Photo> photosTaggedIn = photosTaggedInAdapter.UnboxCollection(boxPhotosTaggedIn);
            FacebookObjectCollection<Photo> photosTaggedTogether = m_FriendshipAnalyzer.PhotosTaggedTogether(photosTaggedIn);

            treeViewTaggedTogether.SetValues(photosTaggedTogether, TreeViewExtenderForFacebookPhotos.eGroupBy.Uploader);
        }

        private void fetchPhotosOfFriendInMyPhotos()
        {
            FacebookObjectCollection<Album> albums = fetchAlbums(FacebookApplication.LoggedInUser);
            FacebookObjectCollection<Photo> photosOfFriend = m_FriendshipAnalyzer.GetPhotosFromAlbumsUserIsTaggedIn(m_FriendshipAnalyzer.Friend, albums);

            treeViewPhotosOfFriendInMyPhotos.SetValues(photosOfFriend, TreeViewExtenderForFacebookPhotos.eGroupBy.Album);
        }

        private FacebookObjectCollection<Album> fetchAlbums(User i_User)
        {
            FormAlbumsSelector formAlbumSelector = new FormAlbumsSelector(i_User);
            Album[] selectedAlbums = formAlbumSelector.GetAlbumsSelection();
            IFacebookCollection<Album> albumsAdapter = new FacebookCollectionAdapter<Album>(eFacebookCollectionType.Albums)
            {
                AlbumsToLoad = selectedAlbums
            };
            FacebookObjectCollection<FacebookObject> boxAlbumsTaggedIn = albumsAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Album> albums = albumsAdapter.UnboxCollection(boxAlbumsTaggedIn);

            return albums;
        }

        private void fetchPhotosOfMeInFriendsPhotos()
        {
            FacebookObjectCollection<Album> albums = fetchAlbums(m_FriendshipAnalyzer.Friend);
            FacebookObjectCollection<Photo> photos = m_FriendshipAnalyzer.GetPhotosFromAlbumsUserIsTaggedIn(FacebookApplication.LoggedInUser, albums);
            treeViewPhotosOfFriendIAmTaggedIn.SetValues(photos, TreeViewExtenderForFacebookPhotos.eGroupBy.Album);
        }

        private void setEventHandlers()
        {
            treeViewPhotosOfFriendInMyPhotos.NodeMouseDoubleClick += (i_Sender, i_Args) => photoTreeViewDoubleClicked(i_Args.Node);
            treeViewTaggedTogether.NodeMouseDoubleClick += (i_Sender, i_Args) => photoTreeViewDoubleClicked(i_Args.Node);
            buttonFetchPhotosOfFriendIAmTaggedIn.Click += (i_Sender, i_Args) => fetchPhotosOfMeInFriendsPhotos();
            buttonFetchTaggedTogether.Click += (i_Sender, i_Args) => fetchPhotosTaggedTogether();
        }

        private void photoTreeViewDoubleClicked(TreeNode i_SelectedNode)
        {
            if (i_SelectedNode.Tag is User)
            {
                User selectedUser = i_SelectedNode.Tag as User;
                FormPictureFrame profile = new FormPictureFrame(selectedUser.PictureLargeURL, selectedUser.Name);
                profile.Show();
            }
            else if (i_SelectedNode.Tag is Photo)
            {
                Photo selectedPhoto = i_SelectedNode.Tag as Photo;
                FormPhotoDetails formPhotoDetails = new FormPhotoDetails(selectedPhoto);
                formPhotoDetails.Show();
            }
        }

        private void friendshipAnalyzerFriendsDockPhoto_MouseClick(object i_Sender, MouseEventArgs i_Args)
        {
            User friend = ((PictureBox)i_Sender).Tag as User;

            if (friend != null)
            {
                m_FriendshipAnalyzer.Friend = friend;
                if (FriendSelectionChanged != null)
                {
                    FriendSelectionChanged.Invoke();
                }
            }
        }

        private void clearAllTreeViews()
        {
            treeViewPhotosOfFriendIAmTaggedIn.Nodes.Clear();
            treeViewPhotosOfFriendInMyPhotos.Nodes.Clear();
            treeViewTaggedTogether.Nodes.Clear();
        }

        private void buttonFetchMyPhotosFriendIsIn_Click(object i_Sender, EventArgs i_Args)
        {
            fetchPhotosOfFriendInMyPhotos();
        }

        private void buttonFetchGeneralData_Click(object i_Sender, EventArgs i_Args)
        {
            friendshipAnalyzerFetchGeneralData();
        }

        private void getMostRecentPhotoTogether()
        {
            IFacebookCollection<Photo> photosTaggedInAdapter = new FacebookCollectionAdapter<Photo>(eFacebookCollectionType.PhotosTaggedIn);
            FacebookObjectCollection<FacebookObject> boxPhotosTaggedIn = photosTaggedInAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Photo> photosTaggedIn = photosTaggedInAdapter.UnboxCollection(boxPhotosTaggedIn);
            FacebookObjectCollection<Photo> photosTaggedTogether = m_FriendshipAnalyzer.PhotosTaggedTogether(photosTaggedIn);
            Photo mostRecentTaggedTogether = m_FriendshipAnalyzer.GetMostRecentPhotoTaggedTogether(photosTaggedTogether);

            if (mostRecentTaggedTogether != null)
            {
                pictureBoxMostRecentTaggedTogether.LoadAsync(mostRecentTaggedTogether.PictureNormalURL);
                pictureBoxMostRecentTaggedTogether.Tag = mostRecentTaggedTogether;
            }
        }

        private void pictureBoxMostRecentTaggedTogether_Click(object i_Sender, EventArgs i_Args)
        {
            Photo photo = ((PictureBox)i_Sender).Tag as Photo;

            if (photo != null)
            {
                FormPhotoDetails formPhotoDetails = new FormPhotoDetails(photo);
                formPhotoDetails.Show();
            }
        }

        private void updateCommentsListBox()
        {
            listBoxPhotosCommentedOn.DisplayMember = "Message";
            listBoxPhotosCommentedOn.Items.Clear();
            foreach (Comment comment in m_FriendshipAnalyzer.CommentsByFriend.Keys)
            {
                listBoxPhotosCommentedOn.Items.Add(new FacebookCommentProxy() { Comment = comment });
            }
        }

        private void listBoxPhotosCommentedOn_MouseDoubleClick(object i_Sender, MouseEventArgs i_Args)
        {
            FacebookCommentProxy selectedComment = ((ListBox)i_Sender).SelectedItem as FacebookCommentProxy;

            if (selectedComment != null)
            {
                new FormPhotoDetails(m_FriendshipAnalyzer.CommentsByFriend[selectedComment.Comment]).Show();
            }
        }
    }
}
