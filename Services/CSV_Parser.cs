using CSV_Parser_Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CSV_Parser_Api.Services
{
    public class CSV_Parser
    {
        public IEnumerable<Employee> CsvParser(HttpPostedFile formFile)
        {
            MemoryStream stream = new MemoryStream();
            formFile.InputStream.CopyTo(stream);
            byte[] bufferMemory = stream.ToArray();

            List<Employee> result = new List<Employee>();

            using (StreamReader sr = new StreamReader(new MemoryStream(bufferMemory)))
            {
                string headerLine = sr.ReadLine();
                string eachLine;
                while ((eachLine = sr.ReadLine()) != null)
                {
                    Employee user = new Employee()
                    {
                        PayrollNumber = eachLine.Split(',')[0],
                        Forenames = eachLine.Split(',')[1],
                        Surname = eachLine.Split(',')[2],
                        DateOfBirth = Convert.ToDateTime(DateTimeCorrector(eachLine.Split(',')[3])),
                        Telephone = eachLine.Split(',')[4],
                        Mobile = eachLine.Split(',')[5],
                        Address = eachLine.Split(',')[6],
                        Address2 = eachLine.Split(',')[7],
                        Postcode = eachLine.Split(',')[8],
                        EmailHome = eachLine.Split(',')[9],
                        StartDate = Convert.ToDateTime(DateTimeCorrector(eachLine.Split(',')[3]))
                    };
                    result.Add(user);
                }


            }
            return result;
        }
        // This method corrects datetime for entity Model(Employee) format that coming from parsing result.
        public string DateTimeCorrector(string value)
        {
            var newValue = value.Split('/');
            value = newValue[1] + "/" + newValue[0] + "/" + newValue[2];
            return value;
        }
    }
}