﻿/*
 * C17_Ex01: FacebookObjectDisplayer.cs
 * 
 * Visitor class to enable displaying objects (connector between logic and UI)
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using System;
    using C17_Ex01_Dudi_200441749_Or_204311997.Forms;

    public class FacebookObjectDisplayer
    {
        public void DisplayObject(IDisplayableObjectHolder i_DisplayableObjectHolderObjectHolder)
        {
            object objectToDisplay = i_DisplayableObjectHolderObjectHolder.ObjectToDisplay;

            try
            {
                Form formToDisplay = DetailsFormFactory.CreateDetailesForm(objectToDisplay);
                formToDisplay.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error while creating details form: {0}", ex.Message));
            }
        }
    }
}
