using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WDBXEditor.Forms
{
    public static class InputBox
    {
        /// <summary>
        /// Generates the VB equivalent input box with label, field and buttons as a dialog
        /// </summary>
        /// <param name="Prompt"></param>
        /// <param name="Title"></param>
        /// <param name="Default"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static DialogResult ShowInputDialog(string Prompt, string Title, string Default, ref string Result)
        {
            System.Drawing.Size size = new(200, 80);
            Form inputBox = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.Sizable,
                ClientSize = size,
                Text = Title,
                MaximizeBox = false,
                MinimizeBox = false
            };
            inputBox.MaximumSize = inputBox.Size;
            inputBox.MinimumSize = inputBox.Size;
            inputBox.ShowIcon = false;

            Label prompt = new()
            {
                Size = new System.Drawing.Size(size.Width - 10, 13),
                Location = new System.Drawing.Point(5, 5),
                Text = Prompt
            };
            inputBox.Controls.Add(prompt);

            TextBox textBox = new()
            {
                Size = new System.Drawing.Size(size.Width - 10, 23),
                Location = new System.Drawing.Point(5, 25),
                Text = Default
            };
            inputBox.Controls.Add(textBox);

            Button okButton = new()
            {
                DialogResult = DialogResult.OK,
                Name = "okButton",
                Size = new System.Drawing.Size(75, 23),
                Text = "&OK",
                Location = new System.Drawing.Point(size.Width - 80 - 80, 49)
            };
            inputBox.Controls.Add(okButton);

            Button cancelButton = new()
            {
                DialogResult = DialogResult.Cancel,
                Name = "cancelButton",
                Size = new System.Drawing.Size(75, 23),
                Text = "&Cancel",
                Location = new System.Drawing.Point(size.Width - 80, 49)
            };
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            Result = textBox.Text;
            return result;
        }

        public static DialogResult ShowOverwriteDialog(string Prompt, string Title)
        {
            System.Drawing.Size size = new(280, 105);
            Form inputBox = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ClientSize = size,
                Text = Title,
                MaximizeBox = false,
                MinimizeBox = false
            };
            inputBox.MaximumSize = inputBox.Size;
            inputBox.MinimumSize = inputBox.Size;
            inputBox.ShowIcon = false;

            Panel panel = new()
            {
                Size = new System.Drawing.Size(size.Width, inputBox.Size.Height - 85),
                Location = new System.Drawing.Point(0, 0),
                BackColor = System.Drawing.Color.White
            };
            inputBox.Controls.Add(panel);

            Label prompt = new()
            {
                Size = new System.Drawing.Size(size.Width - 10, 30),
                Location = new System.Drawing.Point(15, (panel.Size.Height / 2) - 20),
                Text = Prompt,
                Font = new System.Drawing.Font("Segoe UI", 9)
            };
            panel.Controls.Add(prompt);

            Button okButton = new()
            {
                DialogResult = DialogResult.OK,
                Name = "yesButton",
                Size = new System.Drawing.Size(75, 26),
                Text = "Append",
                Location = new System.Drawing.Point(size.Width - 80 - 80 - 80, 69),
                Tag = DialogResult.Yes
            };
            inputBox.Controls.Add(okButton);

            Button overrideButton = new()
            {
                DialogResult = DialogResult.Cancel,
                Name = "overButton",
                Size = new System.Drawing.Size(75, 26),
                Text = "Overwrite",
                Location = new System.Drawing.Point(size.Width - 80 - 80, 69),
                Tag = DialogResult.No
            };
            inputBox.Controls.Add(overrideButton);

            Button cancelButton = new()
            {
                DialogResult = DialogResult.Cancel,
                Name = "cancelButton",
                Size = new System.Drawing.Size(75, 26),
                Text = "Cancel",
                Location = new System.Drawing.Point(size.Width - 80, 69),
                Tag = DialogResult.Cancel
            };
            inputBox.Controls.Add(cancelButton);

            cancelButton.Click += new EventHandler(Button_Click);
            overrideButton.Click += new EventHandler(Button_Click);
            okButton.Click += new EventHandler(Button_Click);

            return inputBox.ShowDialog();
        }

        private static void Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = (DialogResult)(((Button)sender).Tag); //Set the result

            //Find the parent form
            Control cntrl = (Control)sender;
            while (cntrl.GetType() != typeof(Form) && cntrl.Parent != null)
                cntrl = cntrl.Parent;

            if (cntrl.GetType() != typeof(Form)) return; //No parent form found

            //Set the result and close
            ((Form)cntrl).DialogResult = dialogResult;
            ((Form)cntrl).Close();
        }
    }
}
