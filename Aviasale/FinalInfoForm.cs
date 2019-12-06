using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace Aviasale
{
    public partial class FinalInfoForm : Form
    {
        public FinalInfoForm() => InitializeComponent();
        private void FinalInfoForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < PersonalInfoForm.PassengerList.Count; i++)
            {
                ListViewItem item = new ListViewItem(PersonalInfoForm.PassengerList[i].Name);
                item.SubItems.Add(PersonalInfoForm.PassengerList[i].Passport);
                item.SubItems.Add(PersonalInfoForm.PassengerList[i].Age.ToString());
                item.SubItems.Add(PersonalInfoForm.TicketList[i].Type.ToString());
                item.SubItems.Add(PersonalInfoForm.TicketList[i].Price.ToString());
                listView1.Items.Add(item);
            }
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PersonalInfoForm.PassengerList.Count; i++)
            {
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var wordDoc = wordApp.Documents.Add(System.Windows.Forms.Application.StartupPath + "\\Sig.dotx");

                ReplaceStub("#Город", PersonalInfoForm.TicketList[i].ToWhere, wordDoc);
                ReplaceStub("#стоимость", PersonalInfoForm.TicketList[i].Price.ToString(), wordDoc);
                ReplaceStub("#ФИО", PersonalInfoForm.PassengerList[i].Name, wordDoc);
                ReplaceStub("#паспорт", PersonalInfoForm.PassengerList[i].Passport.ToString(), wordDoc);
                ReplaceStub("#дата", PersonalInfoForm.TicketList[i].BuyingTime.ToString(), wordDoc);
                ReplaceStub("#вид", PersonalInfoForm.TicketList[i].Type.ToString(), wordDoc);
                ReplaceStub("#возраст", PersonalInfoForm.PassengerList[i].Age.ToString(), wordDoc);

                wordDoc.SaveAs($"{System.Windows.Forms.Application.StartupPath}\\Билет №{i + 1} {PersonalInfoForm.PassengerList[i].Name}.docx");
                wordDoc.Close();
                wordApp.Quit();
            }
        }

        private void ReplaceStub(string stubToReplace, string text, Document worldDocument)
        {
            var range = worldDocument.Content;
            range.Find.ClearFormatting();
            object wdReplaceAll = WdReplace.wdReplaceAll;
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text, Replace: wdReplaceAll);
        }
    }
}