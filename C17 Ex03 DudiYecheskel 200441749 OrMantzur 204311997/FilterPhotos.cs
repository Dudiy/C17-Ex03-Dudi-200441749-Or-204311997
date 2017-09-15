using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public class FilterPhotos
    {
        public Func<Photo, bool> FilterPhoto { get; set; } = (photo) => true;

        public FacebookObjectCollection<Photo> GetFilterPhotos(FacebookObjectCollection<Album> i_Album)
        {
            FacebookObjectCollection<Photo> filterPhotos = new FacebookObjectCollection<Photo>();

            if (i_Album.Count > 0)
            {
                foreach (Album album in i_Album)
                {
                    FacebookObjectCollection<Photo> filterPhotosInAlbum = GetFilterPhotos(album.Photos);
                    foreach (Photo photo in filterPhotosInAlbum)
                    {
                        filterPhotos.Add(photo);
                    }
                }
            }

            return filterPhotos;
        }

        public FacebookObjectCollection<Photo> GetFilterPhotos(FacebookObjectCollection<Photo> i_Photos)
        {
            FacebookObjectCollection<Photo> filterPhotos = new FacebookObjectCollection<Photo>();

            foreach (Photo photo in i_Photos)
            {
                if (FilterPhoto.Invoke(photo))
                {
                    filterPhotos.Add(photo);
                }
            }

            return filterPhotos;
        }
    }
}
