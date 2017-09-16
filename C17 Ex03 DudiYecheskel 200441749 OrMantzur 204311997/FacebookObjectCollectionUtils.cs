using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public static class FacebookObjectCollectionUtils
    {
        public static FacebookObjectCollection<Photo> FilterAlbumColection(this FacebookObjectCollection<Album> i_Album, Func<Photo, bool> i_FilterMethod)
        {
            FacebookObjectCollection<Photo> filteredPhotosCollection = new FacebookObjectCollection<Photo>();

            if (i_Album.Count > 0)
            {
                foreach (Album album in i_Album)
                {
                    FacebookObjectCollection<Photo> filterPhotosInAlbum = FilterPhotoColection(album.Photos, i_FilterMethod);
                    foreach (Photo photo in filterPhotosInAlbum)
                    {
                        filteredPhotosCollection.Add(photo);
                    }
                }
            }

            return filteredPhotosCollection;
        }

        public static FacebookObjectCollection<Photo> FilterPhotoColection(this FacebookObjectCollection<Photo> i_Photos, Func<Photo, bool> i_FilterMethod)
        {
            FacebookObjectCollection<Photo> filteredPhotosCollection = new FacebookObjectCollection<Photo>();

            foreach (Photo photo in i_Photos)
            {
                if (i_FilterMethod.Invoke(photo))
                {
                    filteredPhotosCollection.Add(photo);
                }
            }

            return filteredPhotosCollection;
        }

        public static Post GetMostRecentPost(this FacebookObjectCollection<Post> i_Collection)
        {
            Post mostRecentPost;

            using (IEnumerator<Post> enumerator = i_Collection.GetEnumerator())
            {
                enumerator.MoveNext();
                mostRecentPost = enumerator.Current;
            }

            return mostRecentPost;
        }
    }
}
