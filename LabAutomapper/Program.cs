using System;
using LabAutomapper.Models;
using LabAutomapper.DTOs;
using System.Collections.Generic;
using AutoMapper;

namespace LabAutomapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/// Automapper LAB ///");

            //Automapepr -> Setup
            MapperConfiguration config = InitializeAutomapper();
            Mapper mapper = new Mapper(config);

            // Get fake data
            List<Employee> employees = CreateEmployees();

            //Automapepr -> Map
            List<EmployeeDTO> employeesDTO = mapper.Map<List<EmployeeDTO>>(employees);

            foreach(EmployeeDTO e in employeesDTO)
            {
                Console.WriteLine($" - EMMPLOYEE: {e.FullName} (bday: {e.Birthday.ToShortDateString()}) at department {e.Department.Name}");
            }

            Console.ReadKey();
        }

        private static MapperConfiguration InitializeAutomapper()
        {
            var config =
                new MapperConfiguration(
                    cfg =>
                    {
                        cfg.CreateMap<Department, DepartmentDTO>();

                        cfg.CreateMap<Employee, EmployeeDTO>()
                            .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name + " " + src.Surname))
                            .ForMember(dest => dest.Department, act => act.MapFrom(src => src.Department));

                    }
                );

            return config;
        }

        /// <summary>
        /// Creates a fake list of employees with fake departments
        /// </summary>
        /// <returns>The list</returns>
        private static List<Employee> CreateEmployees()
        {
            var employees = new List<Employee>();
            Department deptHR = new Department
            {
                Name = "Human Resources"
            };
            Department deptTI = new Department
            {
                Name = "IT"
            };

            employees = new List<Employee>
            {
                new Employee
                {
                    Name = "David Biencinto",
                    Birthday = new DateTime(1976,1,14),
                    Department = deptTI
                },
                new Employee
                {
                    Name = "Adan Martín",
                    Birthday = new DateTime(1980,5,31),
                    Department = deptTI
                },
                new Employee
                {
                    Name = "Ford Fairlane",
                    Birthday = new DateTime(1978,3,11),
                    Department = deptHR
                },
                new Employee
                {
                    Name = "Paula Gómez",
                    Birthday = new DateTime(1978,3,11),
                    Department = deptHR
                }

            };

            return employees;
        }


    }
}

