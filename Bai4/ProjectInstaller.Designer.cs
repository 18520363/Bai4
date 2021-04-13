
namespace Bai4
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerBai4 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerBai4 = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerBai4
            // 
            this.serviceProcessInstallerBai4.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstallerBai4.Password = null;
            this.serviceProcessInstallerBai4.Username = null;
            // 
            // serviceInstallerBai4
            // 
            this.serviceInstallerBai4.Description = "Bai4 demo";
            this.serviceInstallerBai4.DisplayName = "Bai4.Demo";
            this.serviceInstallerBai4.ServiceName = "Bai4";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerBai4,
            this.serviceInstallerBai4});

            this.serviceInstallerBai4.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
        }



        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerBai4;
        private System.ServiceProcess.ServiceInstaller serviceInstallerBai4;
    }
}