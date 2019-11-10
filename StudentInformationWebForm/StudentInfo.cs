using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInformationWebForm
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PhoneNo { get; set; }

        //public int SectionId { get; set; }


        public StudentInfo()
        {

        }
        public StudentInfo(string section, string studentId, string name, string fatherName, string motherName,string phoneNo)
        {
            Section = section;
            StudentID = studentId;
            Name = name;
            FatherName = fatherName;
            MotherName = motherName;
            PhoneNo = phoneNo;
        }
    }
}