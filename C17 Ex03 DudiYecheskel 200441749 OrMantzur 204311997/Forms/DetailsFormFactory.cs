using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    internal abstract class DetailsFormFactory
    {
        public static Form CreateDetailesForm(object i_ObjectToDisplay)
        {
            Form formCreated;

            if (i_ObjectToDisplay is Photo)
            {
                formCreated = new FormPhotoDetails(i_ObjectToDisplay as Photo);
            }
            else if (i_ObjectToDisplay is User)
            {
                formCreated = new FormFriendDetails(i_ObjectToDisplay as User);
            }
            else if (i_ObjectToDisplay is Page)
            {
                formCreated = new FormPictureFrame(((Page)i_ObjectToDisplay).PictureLargeURL);
            }
            else if (i_ObjectToDisplay is Post)
            {
                formCreated = new FormPostDetails((Post)i_ObjectToDisplay);
            }
            else
            {
                throw new ArgumentException(string.Format("Object of type {0} is not supported", i_ObjectToDisplay.GetType().Name));
            }

            return formCreated;
        }
    }
}
