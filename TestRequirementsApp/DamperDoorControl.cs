// © Parata Systems, LLC 2010
// All rights reserved.

using System;
using System.Windows.Forms;

namespace Requirements_Builder
{
    public partial class DamperDoorControl : UserControl
    {
        String cellLocation = "1A";
        const String solenoidFormat = "Cell{0}_DamperDoorSolenoid";

        public DamperDoorControl()
        {
        }

        public DamperDoorControl(IRemoteControlsObjectFactory factory)
            : this()
        {
            initialize(factory);
        }

        public void initialize(IRemoteControlsObjectFactory factory)
        {
            this.factory = factory;
            getSolenoid();
        }

        private void getSolenoidButton_Click(object sender, EventArgs e)
        {
            if (cellLocationBox.IsEmpty)
            {
                MessageBox.Show("Please enter a cell location.");
                return;
            }

            if (!factory.hasRemoteObject(cellLocationBox.Text))
            {
                MessageBox.Show(String.Format("Cannot find a damper door solenoid for location \"{0}\"", cellLocationBox.Text));
                return;
            }

            cellLocation = cellLocationBox.Text;
            getSolenoid();
        }

        private string getSolenoidName()
        {
            return getSolenoidName(cellLocation);
        }

        private String getSolenoidName(String location)
        {
            return String.Format(solenoidFormat, location);
        }


        private void getSolenoid()
        {
            //if (solenoid != null)
            //{
            //    solenoid.StatusUpdateEvent -= RemotingUtilities.wrapRemoteEvent<RemoteNumericIOEventArgs>(handleSolenoidUpdate);
            //}

            //if (!factory.hasRemoteObject(getSolenoidName()))
            //{
            //    return;
            //}

            //solenoid = factory.getRemoteObject(getSolenoidName()) as IRemoteNumericIO;
            //if (solenoid != null)
            //{
            //    solenoid.StatusUpdateEvent += RemotingUtilities.wrapRemoteEvent<RemoteNumericIOEventArgs>(handleSolenoidUpdate);
            //    handleSolenoidUpdate(this, new RemoteNumericIOEventArgs(solenoid.Name, solenoid.State, solenoid.ErrorStatus, solenoid.Value));
            //}
        }

        void handleSolenoidUpdate(object sender, EventArgs e)
        {
            this.invokeMethod(() =>
            {
                solenoidNameLabel.Text = e.ToString();
                solenoidStateLabel.Text = e.ToString();
            });
        }

        private void activateButton_Click(object sender, EventArgs e)
        {
            if (solenoid != null)
            {
                solenoid.setActive();
            }
        }

        private void inactivateButton_Click(object sender, EventArgs e)
        {
            if (solenoid != null)
            {
                solenoid.setInactive();
            }
        }
    }
}
