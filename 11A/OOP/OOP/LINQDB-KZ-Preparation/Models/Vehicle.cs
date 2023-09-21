//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LINQDB_KZ_Preparation.Models
//{
//    public class Vehicle
//    {
//        public Vehicle()
//        {
//            VehicleUsers = new HashSet<UserVehicle>();
//        }
        
//        public int Id { get; set; }

//        public string Model { get; set; }

//        public ICollection<UserVehicle> VehicleUsers { get; set; }

//    }


//    public class UserVehicle
//    {
//        [ForeignKey(nameof(Models.Employee))]
//        public int EmployeeId { get; set; }
//        public virtual Employee Employee {get;set;}

//        [ForeignKey(nameof(Models.Vehicle))]
//        public int CarId { get; set; }
//        public virtual Vehicle Vehicle { get; set; }



//    }





//}
