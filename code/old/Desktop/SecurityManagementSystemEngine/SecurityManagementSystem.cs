using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityManagementSystemEngine
{
    public class SecurityManagementController
    {
        public VisitorManager employeeController;
        public MemberManager customerController;
        public EmployeeManager empController;
        public NotificationController notificator;
        public RequestController requestHandler;
        
    }

    public class EmployeeManager
    {
        public List<EmployeeInfo> employees;
        public List<RequestInfo> reqHandled;
    }

    public class MemberManager
    {
        public List<MemberInfo> members;
        public List<PreferenceInfo> prefs;        
    }

    public class VisitorManager
    {
        public List<VisitorInfo> visitors;
        public List<VisitInfo> visits;
    }

    public class NotificationController
    {
        public List<NotificationInfo> notifications;
    }

    public class RequestController
    {
        public List<RequestInfo> requests;
    }

    public enum VisitType
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
        public List<PreferenceInfo> prefs;
        public List<RequestInfo> reqs;
    }

    public class EmployeeInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public DateTime doj { get; set; }
        public string department { get; set; }
    }

    public class VisitorInfo
    {
        public string id { get; set; }
        public string photoIdNo { get; set; }
        public string photoFilePath { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public VisitType postType { get; set; }
        public List<VisitInfo> lastVisits;
    }

    public class VisitInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public MemberInfo memberTargeted { get; set; }
        public EmployeeInfo employeeAuthroized { get; set; }      
        public DateTime start { get; set; }
        public DateTime duration { get; set; }
    }
    public class PreferenceInfo
    {
        string name;
        EmployeeInfo technicianTargeted;
        string Description;
        DateTime date;
    }

    public enum NotificationType
    {
        Visit,
        Timeout,
        Issue,
        Other
    }

    public class NotificationInfo
    {
        string name;
        EmployeeInfo employeeEdited;
        MemberInfo memberTargeted;
        VisitorInfo visitorRelated;
        string description;
        DateTime date;
        NotificationType type;
    }

    public enum RequestType
    {
        Emergency,
        Distress,
        Household,
        other
    }

    public class RequestInfo
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public RequestType type { get; set; }
        public string description { get; set; }
    }

}
