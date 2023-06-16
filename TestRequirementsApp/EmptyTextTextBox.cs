// © Parata Systems, LLC 2009
// All rights reserved.

using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Nuvo.Requirements_Builder
{
    public class EmptyTextTextBox : TextBox
    {
        #region Fields

        private String emptyText;
        private Color emptyForeColor;

        #endregion Fields

        #region Properties

        [Description("The color of the text that is displayed when the text box is not empty.")]
        public Color NonEmptyForeColor { get; set; }

        [Description("The text to display when the text box is empty.")]
        public String EmptyText
        {
            get { return emptyText; }

            set
            {
                emptyText = value;
                setEmptyText();
            }
        }

        public bool IsEmpty
        {
            get { return Text.Equals(EmptyText) || String.IsNullOrEmpty(Text); }
        }

        [Description("The color of the text that is displayed when the text box is empty.")]
        public Color EmptyForeColor
        {
            get { return emptyForeColor; }
            set
            {
                emptyForeColor = value;
                setForeColor();
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                NonEmptyForeColor = value;
                setForeColor();
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                setForeColor();
            }
        }

        #endregion Properties

        #region Constructors

        public EmptyTextTextBox()
            : base()
        {
            EmptyForeColor = SystemColors.GrayText;
            NonEmptyForeColor = ForeColor;

            setEmptyText();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Clears any entry in the text box, displaying the EmptyText.
        /// </summary>
        public new void Clear()
        {
            Text = String.Empty;
            setEmptyText();
        }

        protected override void OnEnter(EventArgs e)
        {
            if (Text.Equals(EmptyText))
            {
                Text = String.Empty;
            }

            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            setEmptyText();
            base.OnLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            setForeColor();
            base.OnTextChanged(e);
        }

        private void setForeColor()
        {
            if (Text.Equals(EmptyText))
            {
                base.ForeColor = EmptyForeColor;
            }
            else
            {
                base.ForeColor = NonEmptyForeColor;
            }
        }

        private void setEmptyText()
        {
            if (String.IsNullOrEmpty(Text))
            {
                Text = EmptyText;
            }
        }

        #endregion Methods
    }
}
