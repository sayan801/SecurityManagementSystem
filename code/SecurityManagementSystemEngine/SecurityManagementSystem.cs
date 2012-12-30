using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityManagementSystemEngine
{
    public class SecurityManagementController
    {
        public EmployeeManager employeeController;
        public MemberManager customerController;
        public List<ReportInfo> reports;
        public List<VisitInfo> payments;
    }

    public class EmployeeManager
    {
        public List<EmployeeInfo> employees;
    }

    public class MemberManager
    {
        public List<MemberInfo> customers;
    }

    public class PhotoEditController
    {
        public List<PhotoEditInfo> edits;
    }

    public enum PostType
    {
        Technician,
        Admin,
        Owner
    }

    public class MemberInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }        
        public DateTime doj { get; set; }
        public string department { get; set; }
        public List<PreferenceInfo> photos;
    }

    public class EmployeeInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public PostType postType { get; set; }
        public DateTime doj { get; set; }
        public string department { get; set; }
    }

    public class VisitorInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public PostType postType { get; set; }
        public List<VisitInfo> payements;
    }

    public class VisitInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string customerId { get; set; }
        public double amount { get; set; }
        public DateTime dop { get; set; }
    }
    public class PreferenceInfo
    {
        string name;
        string softwareUsedForCapture;
        EmployeeInfo technicianTaken;
        string ImageFile;
        double size;
        DateTime dateTaken;
        List<PhotoEditInfo> edits;
    }

    public enum PhotoEditType
    {
        Rotate,
        Crop,
        Stretch,
        Brighten,
        Sepia
    }

    public class PhotoEditInfo
    {
        string name;
        string softwareUsedtoEdit;
        EmployeeInfo technicianEdited;
        string OriginalImageFile;
        string EditedImageFile;
        double size;
        DateTime dateEdited;
        PhotoEditType type;
    }

    public enum ReportType
    {
        Single,
        Daily,
        Weekly,
        Monthly,
        Quarterly,
        Yearly
    }

    public class ReportInfo
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public ReportType type { get; set; }
        public string description { get; set; }
    }

}
