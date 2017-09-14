﻿/*
 * C17_Ex01: FormFriendDetails.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    public partial class FormFriendDetails : Form
    {
        private readonly User r_Friend;

        public FormFriendDetails(User i_Friend)
        {
            this.InitializeComponent();
            this.r_Friend = i_Friend;
        }

        protected override void OnShown(EventArgs i_Args)
        {
            base.OnShown(i_Args);
            labelLikedPage.Text = string.Format(
@"Pages that {0} liked",
r_Friend.FirstName);
            if (!string.IsNullOrEmpty(labelBirthday.Text))
            {
                labelBirthdayTitle.Visible = false;
                labelBirthday.Visible = false;
            }
            userBindingSource.DataSource = r_Friend;
        }

        private void linkLabelLikedPageUrl_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_Args)
        {
            // Specify that the link was visited.
            this.linkLabelLikedPageURL.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start(this.linkLabelLikedPageURL.Text);
        }
    }
}
