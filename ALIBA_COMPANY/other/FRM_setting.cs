using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIBA_COMPANY.other
{
    public partial class FRM_setting : DevExpress.XtraEditors.XtraForm
    {
      
        public int Start;
        public FRM_setting()
        {
            InitializeComponent();
        }

            private void RadioButton1_CheckedChanged(object sender, EventArgs e)
            {
                SetConType();
            }

            private void SetConType()
            {
                if (radioButton1.Checked == true)
                {
                    edt_port.Enabled = false;
                    edt_username.Enabled = false;
                    edt_password.Enabled = false;
                }
                else
                {
                    edt_port.Enabled = true;
                    edt_username.Enabled = true;
                    edt_password.Enabled = true;
                }
            }

            private void Btn_saveconstring_Click(object sender, EventArgs e)
            {
                // Method to save
                SaveConStrign();
                // Method to Ecryp constring
                //Encrypteconstring();
            }


            private void SaveConStrign()
            {
           
            // Get input
                var server = edt_servername.Text.Trim();
                var dbname = edt_database.Text.Trim();
                var port = "," + edt_port.Text.Trim();
                var user = edt_username.Text.Trim();
                var password = edt_password.Text.Trim();

                if (radioButton1.Checked == true)
                {
                    // Local Con
                    var ConString = @"1metadata=res://*/M5.csdl|res://*/M5.ssdl|res://*/M5.msl;provider=System.Data.SqlClient;provider connection string=';data source="+ server + " ;initial catalog=" + dbname + ";integrated security=true;MultipleActiveResultSets=True;App=EntityFramework';";

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["AlibaRamyEntities"].ConnectionString = ConString;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");

                

                MessageBox.Show("تم تحديث الاتصال بنجاح , سيتم اعادة تشغيل البرنامج لتطبيق الاعدادات ");
                Application.Restart();
                }
                else
                {
                    // network Con
                var ConString = @"metadata=res://*/M5.csdl|res://*/M5.ssdl|res://*/M5.msl;provider=System.Data.SqlClient;provider connection string=';data source=" + server + port + ";initial catalog=" + dbname + ";user id=" + user + ";password=" + password + ";connect Timeout=30;MultipleActiveResultSets=True;App=EntityFramework';";

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["AlibaRamyEntities"].ConnectionString = ConString;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
                MessageBox.Show("تم تحديث الاتصال بنجاح , سيتم اعادة تشغيل البرنامج لتطبيق الاعدادات ");
                Application.Restart();
                }
                
            }

            /*  private void Encrypteconstring()
              {
                  var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                  ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                  configFileMap.ExeConfigFilename = config.FilePath;
                  System.Configuration.Configuration myConfig = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                  ConnectionStringsSection section = myConfig.GetSection("connectionStrings") as ConnectionStringsSection;

                  if (section.SectionInformation.IsProtected)
                  {
                      // Remove encryption.
                      section.SectionInformation.UnprotectSection();
                  }
                  else
                  {
                      // Encrypt the section.
                      section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                  }

                  myConfig.Save();
              }*/

            private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
            {
                if (Start == 1)
                {
                    Application.Exit();
                }
            }

      
    }
    }