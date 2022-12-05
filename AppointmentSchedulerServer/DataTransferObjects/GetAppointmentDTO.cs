﻿using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;
using System.Collections;

namespace AppointmentSchedulerServer.DataTransferObjects
{
    public class GetAppointmentDTO
    {
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ArrayList EmployeeNameList { get; set; }

        public GetAppointmentDTO()
        {

        }

        public GetAppointmentDTO(long id, DateTime time, int timeSlot, bool isApproved, string name, string description, string email, string username)
        {
            Id = id;
            Time = time;
            TimeSlot = timeSlot;
            IsApproved = isApproved;
            Name = name;
            Description = description;
            EmployeeNameList = new ArrayList();
            Username = username;
            Email = email;
        }
    }
}
