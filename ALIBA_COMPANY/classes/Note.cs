using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALIBA_COMPANY.classes
{
    public class Note
    {
        public void AddNote(string Description, pages.Notifications control, string Type1, int Type2)
        {
            try
            {
                var UserID = AddPage.Users.Idd;
                var FullName = AddPage.Users.FullName;
                using (var db = new AlibaRamyEntities())
                {
                   
                    TB_Note note = new TB_Note
                    {
                        NoteDes = Description,
                        NoteUser = FullName,
                        NoteDate = DateTime.Now,
                        NoteType = Type1
                    };
                    TB_mov Log = new TB_mov
                    {
                        mov_dis = Description,
                        user_id = UserID,
                        mov_date = DateTime.Now,
                        amov_id = Type2
                    };
                    db.Entry(Log).State = System.Data.Entity.EntityState.Added;
                    db.Entry(note).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    // update notifications
                    control.LoadData();
                }   

            }
            catch
            {

            }
        }
    }
}
