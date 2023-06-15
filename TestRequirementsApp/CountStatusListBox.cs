// © Parata Systems, LLC 2010
// All rights reserved.

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Requirements_Builder
{
    partial class CountStatusListBox : ListViewFlickerFree
    {
        #region Properties


        #endregion Properties

        #region Constructors

        public CountStatusListBox()
        {
        }

        #endregion Constructors

        #region Methods

        public void add(string status)
        {
            
        }

        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            //if (!e.IsSelected)
            //{
            //    SelectedStatus = null;
            //}

            //var item = e.Item as CountStatusListViewItem;
            //if (item != null && e.IsSelected)
            //{
            //    SelectedStatus = item.Status;
            //}

            //base.OnItemSelectionChanged(e);
        }

        #endregion Methods

        #region Types

        class CountStatusListViewItem : ListViewItem
        {
            #region Fields

            #endregion Fields

            #region Events

            #endregion Events

            #region Properties

            public string Status { get; private set; }

            #endregion Properties

            #region Constructors

            public CountStatusListViewItem(string countStatus)
                : base(String.Empty)
            {
                Status = countStatus;
                addSubItems(countStatus);
            }

            #endregion Constructors

            #region Methods

            private void addSubItems(string countStatus)
            {
                addSubItems(countStatus);
                    //countStatus.Location,
                    //countStatus.SerialNumber.ToString(),
                    //countStatus.State.ToString(),
                    //countStatus.QuantityCounted.ToString(),
                    //countStatus.PillRate.ToString(),
                    //countStatus.JamCount.ToString(),
                    //countStatus.ErrorStatus.ToString());
            }

            private void addSubItems(String location, String serialNumber, String state, String quantity, String countRate, String jams, String information)
            {
                this.SubItems.Add(location);
                this.SubItems.Add(serialNumber);
                this.SubItems.Add(state);
                this.SubItems.Add(quantity);
                this.SubItems.Add(countRate);
                this.SubItems.Add(jams);
                this.SubItems.Add(information);
            }

            #endregion Methods
        }

        #endregion Types
    }
}
