/*
 * C17_Ex01: FriendshipAnalyzer.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using C17_Ex01_Dudi_200441749_Or_204311997.Adapter;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public class FriendshipAnalyzer
    {
        private readonly object r_GetAllPhotosLock = new object();
        private bool m_FinishedFetchingComments;
        private bool m_FinishedFetchingLikes;
        private FacebookObjectCollection<Photo> m_AllPhotos;
        public event Action FinishedFetchingLikesAndComments;
        public Dictionary<Comment, Photo> CommentsByFriend { get; }

        public FacebookObjectCollection<Photo> PhotosFriendLiked { get; }

        public User Friend { get; set; }

        public FriendshipAnalyzer()
        {
            CommentsByFriend = new Dictionary<Comment, Photo>();
            PhotosFriendLiked = new FacebookObjectCollection<Photo>();
        }

        public FacebookObjectCollection<Photo> AllPhotos
        {
            get
            {
                // double check lock so all photos are fetched only once
                if (m_AllPhotos == null)
                {
                    lock (r_GetAllPhotosLock)
                    {
                        if (m_AllPhotos == null)
                        {
                            FacebookCollectionAdapter<Photo> allPhotosAdapter = new FacebookCollectionAdapter<Photo>(eFacebookCollectionType.AlbumPhotos);
                            FacebookObjectCollection<FacebookObject> boxAllPhotosTaggedIn = allPhotosAdapter.FetchDataWithProgressBar();
                            m_AllPhotos = allPhotosAdapter.UnboxCollection(boxAllPhotosTaggedIn);
                        }
                    }
                }

                return m_AllPhotos;
            }
        }

        public FacebookObjectCollection<Photo> PhotosTaggedTogether(FacebookObjectCollection<Photo> i_PhotosTaggedIn)
        {
            Func<Photo, bool> strategyMethod = photo => photo.Tags != null && photo.Tags.Find(tag => tag.User.Id == Friend.Id) != null;

            return i_PhotosTaggedIn.FilterPhotoColection(strategyMethod);
        }

        public FacebookObjectCollection<Photo> GetPhotosFromAlbumsUserIsTaggedIn(User i_UserTagged, FacebookObjectCollection<Album> i_Albums)
        {
            Func<Photo, bool> strategyMethod = photo => photo.Tags != null && photo.Tags.Find(tag => tag.User.Id == i_UserTagged.Id) != null;

            return i_Albums.FilterAlbumColection(strategyMethod);
        }

        public void CountNumberOfPhotosFriendLiked(Action i_PromoteProgressBar)
        {
            m_FinishedFetchingLikes = false;
            try
            {
                foreach (Photo photo in AllPhotos)
                {
                    if (photo.LikedBy.Find(user => user.Id == Friend.Id) != null)
                    {
                        PhotosFriendLiked.Add(photo);
                    }

                    i_PromoteProgressBar.Invoke();
                }
            }
            catch (Exception e)
            {
                if (!(e.InnerException is ThreadAbortException) && !(e is ThreadAbortException))
                {
                    string message = string.Format("Error while counting likes: {0}", e.Message);
                    MessageBox.Show(message);
                }
            }
            finally
            {
                m_FinishedFetchingLikes = true;
                fetchComplete();
            }
        }

        public void CountNumberOfPhotosFriendCommented(Action i_PromoteProgressBar)
        {
            CommentsByFriend.Clear();
            m_FinishedFetchingComments = false;
            try
            {
                foreach (Photo photo in AllPhotos)
                {
                    Comment commentByFriend = photo.Comments.Find(comment => comment.From.Id == Friend.Id);
                    if (commentByFriend != null)
                    {
                        CommentsByFriend.Add(commentByFriend, photo);
                    }

                    i_PromoteProgressBar.Invoke();
                }
            }
            catch (Exception e)
            {
                if (!(e.InnerException is ThreadAbortException) && !(e is ThreadAbortException))
                {
                    string message = string.Format("Error while counting comments: {0}", e.Message);
                    MessageBox.Show(message);
                }
            }
            finally
            {
                m_FinishedFetchingComments = true;
                fetchComplete();
            }
        }

        // IEnumerator
        public Photo GetMostRecentPhotoTaggedTogether(FacebookObjectCollection<Photo> i_PhotosTaggedTogether)
        {
            Photo mostRecentPhoto;

            using (IEnumerator<Photo> enumerator =
                i_PhotosTaggedTogether.OrderByDescending(i_Photo => i_Photo.CreatedTime).GetEnumerator())
            {
                enumerator.MoveNext();
                mostRecentPhoto = enumerator.Current;
            }

            return mostRecentPhoto;
        }

        private void fetchComplete()
        {
            if (m_FinishedFetchingComments && m_FinishedFetchingLikes)
            {
                if (FinishedFetchingLikesAndComments != null)
                {
                    FinishedFetchingLikesAndComments.Invoke();
                }
            }
        }
    }
}
