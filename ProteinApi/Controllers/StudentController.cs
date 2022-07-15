using Microsoft.AspNetCore.Mvc;
using N11CityServiceReference;

namespace ProteinApi.Controllers
{

    public class CommonResponse<T>
    {

        public CommonResponse(T data)
        {
            Data = data;
        }

        public CommonResponse(string error)
        {
            Error = error;
            Success = false;
        }

        public bool Success { get; set; } = true;
        public string Error { get; set; }
        public T Data { get; set; }

    }


    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

    }


    [Route("protein/api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        public StudentController()
        {

        }

        private async Task<CommonResponse<GetCityResponse1>> CallSoapService()
        {
            CityServicePortClient service = new CityServicePortClient();
            var request = new GetCityRequest1();
            request.GetCityRequest = new GetCityRequest();
            request.GetCityRequest.auth = new Authentication { appKey="", appSecret=""};
            request.GetCityRequest.cityCode = "TR";

            GetCityResponse1 response = await service.GetCityAsync(request);

            if (response.GetCityResponse.result.status == "1")
            {
                return new CommonResponse<GetCityResponse1>(response.GetCityResponse.result.errorMessage);
            }

            return new CommonResponse<GetCityResponse1>(response);
        }

        private CommonResponse<List<Student>> GetList()
        {
            List<Student> list = new();
            list.Add(new Student { Id = 1, Age = 23, Email = "email.com", Lastname = "Irmka", Name = "Etem" });
            list.Add(new Student { Id = 2, Age = 24, Email = "email.com", Lastname = "Irmka", Name = "Etem2" });
            list.Add(new Student { Id = 3, Age = 25, Email = "email.com", Lastname = "Irmka", Name = "Etem3" });
            list.Add(new Student { Id = 4, Age = 26, Email = "email.com", Lastname = "Irmka", Name = "Etem4" });
            return new CommonResponse<List<Student>>(list);
        }


        [HttpGet]
        public CommonResponse<List<Student>> Get()
        {
            return GetList();
        }

        [HttpGet("{id}")]
        public CommonResponse<Student> GetById(long id)
        {
            List<Student> list = GetList().Data;
            Student student = list.Where(x => x.Id == id).FirstOrDefault();
            return new CommonResponse<Student>(student);
        }

        [HttpGet]
        [Route("GetByFilter")]
        public CommonResponse<List<Student>> Get([FromQuery]string name, string lastname)
        {
            List<Student> list = GetList().Data;
            List<Student> students = list.Where(x => x.Name.Contains(name) || x.Lastname.Contains(lastname)).ToList();
            return new CommonResponse<List<Student>>(students);
        }


        [HttpPost]
        public CommonResponse<List<Student>> Post([FromBody] Student student)
        {
            List<Student> list = GetList().Data;
            list.Add(student);
            return new CommonResponse<List<Student>>(list.ToList()); 
        }

        [HttpPut]
        public CommonResponse<List<Student>> Put([FromBody] Student request)
        {
            List<Student> list = GetList().Data;
            Student student = list.Where(x => x.Id == request.Id).FirstOrDefault();
            list.Remove(student);
            list.Add(request);
            return new CommonResponse<List<Student>>(list.ToList());
        }

        [HttpDelete("{id}")]
        public CommonResponse<List<Student>> Delete(long id)
        {
            List<Student> list = GetList().Data;
            Student student = list.Where(x => x.Id == id).FirstOrDefault();
            list.Remove(student);
            return new CommonResponse<List<Student>>(list.ToList());
        }

    }
}
