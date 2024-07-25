using Core.Data;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controller
{
    public interface CompanyController
    {
        string SaveCompanyData(Company company);
        List<Company> ReadCompanyData(string companyName);
        List<Company> ReadAllCompnay();

    }

    public class CompanyControllerImpl : CompanyController
    {
        public List<Company> ReadAllCompnay()
        {
            using MyDbContext db = new MyDbContext();

            using (var context = new MyDbContext())
            {
                var c = context.company
                                      .ToList();

                //foreach (Post p in prePost)
                //{
                //    Console.WriteLine($"{student.StudentId} - {student.FirstName} {student.LastName}");
                //}

                //if (c.Count == 0)
                //{
                //    message = "There are no companies registered!";
                //}
                //else
                //{
                //    message = "User name  already exists!!!";
                //}
                return c.ToList();
            }
        }

        public List<Company> ReadCompanyData(string companyName)
        {
            using MyDbContext db = new MyDbContext();

            using (var context = new MyDbContext())
            {
                var c = context.company
                                      .Where(s=>s.CompanyName == companyName)
                                      .ToList();

                //foreach (Post p in prePost)
                //{
                //    Console.WriteLine($"{student.StudentId} - {student.FirstName} {student.LastName}");
                //}

                //if (c.Count == 0)
                //{
                //    message = "There are no companies registered!";
                //}
                //else
                //{
                //    message = "User name  already exists!!!";
                //}
                return c.ToList();
            }
        }

        public string SaveCompanyData(Company companyData)
        {
            string message;

            using MyDbContext db = new MyDbContext();

            using (var context = new MyDbContext())
            {
                var c = context.company
                                      .Where(s => s.UserName == companyData.UserName )
                                      .ToList();

                //foreach (Post p in prePost)
                //{
                //    Console.WriteLine($"{student.StudentId} - {student.FirstName} {student.LastName}");
                //}

                if (c.Count == 0)
                {
                    Company c1 = new Company()
                    {
                        CompanyName = companyData.CompanyName,
                        CompanyLocation = companyData.CompanyLocation,
                        CompanyEmail = companyData.CompanyEmail,
                        UserName = companyData.UserName,
                        Password = companyData.Password
                    };

                    context.Add(c1);
                    context.SaveChanges();
                    message = "Company successfully Registered!!!";
                }
                else
                {
                    message = "User name  already exists!!!";
                }
            }


            return message;
        }
    }
}
