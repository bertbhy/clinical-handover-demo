using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Controllers;
using webapi.Models;
using webapi.Resources;
using webapi.Services;
using Xunit;

namespace testapi.Controllers
{
    public class PmiControllerTest
    {
        private readonly Mock<IPmiService> _pmiService;
        private readonly MockData _mockData;
        public PmiControllerTest()
        {
            _pmiService = new Mock<IPmiService>();
            _mockData = new MockData();
        }

        [Fact]
        public async Task GetPatient()
        {
            var key = _mockData.GetWardPatients[2].PatientKey;
            _pmiService.Setup(s => s.GetPatient(It.Is<string>(s => s == key)))
            .ReturnsAsync(_mockData.GetWardPatients[2]);

            var controller = new PmiController(_pmiService.Object);
            var response = await controller.GetPatient(key);
           
            Assert.IsType<OkObjectResult>(response.Result); 
            var value = (GetWardPatient)((OkObjectResult)response.Result).Value;
            Assert.True(key == value.PatientKey);
        }

        [Fact]
        public async Task QueryPatient()
        {
            var mockData = _mockData.GetWardPatients[2];

            _pmiService.Setup(s => s.QueryPatient(null, null, null, null, 1, 1))
            .ReturnsAsync(new GridQueryResponse<GetWardPatient>()
            {
                TotalRows = 1,
                Rows = new List<GetWardPatient>() { mockData }
            });

            var controller = new PmiController(_pmiService.Object);
            var response = await controller.QueryPatient(null, null, null, 1, 1);

            Assert.IsType<OkObjectResult>(response.Result);
            var value = (GridQueryResponse<GetWardPatient>)((OkObjectResult)response.Result).Value;
            Assert.True(1 == value.Rows.Count());
            Assert.True(1 == value.TotalRows);
        }
    }
}