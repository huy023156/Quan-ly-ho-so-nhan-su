using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class SD
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_EMPLOYEE = "Employee";

        public enum ViolationType
        {
            Late,
            Absence,
            Misconduct,
            Theft,
            Insubordination,
            Harassment,
            DrugUse,
            AlcoholUse,
            PerformanceIssues,
            ConfidentialityBreach,
            Fraud
        }

        public enum ActionTakenType
        {
            VerbalWarning,
            WrittenWarning,
            SuspensionWithoutPay,
            SuspensionWithPay,
            ReductionInPay,
            Demotion,
            Termination,
            Fine
        }

        public enum RewardType
        {
            Bonus,
            Promotion,
            SalaryIncrease,
            GiftCard,
            PublicRecognition,
            EmployeeOfTheMonth,
            CertificateOfRecognition,
            TrainingOpportunity
        }
    }
}
