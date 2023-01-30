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
    public class HandoverControllerTest
    {
        private readonly Mock<IHandoverService> _handoverService;
        private readonly MockData _mockData;
        public HandoverControllerTest()
        {
            _handoverService = new Mock<IHandoverService>();
            _mockData = new MockData();
        }

        [Fact]
        public async Task GetHandover()
        {
            var key = _mockData.Handovers[2].patientKey;
            _handoverService.Setup(s => s.GetHandover(It.Is<string>(s => s == key)))
            .ReturnsAsync(_mockData.Handovers[2]);

            var controller = new HandoverController(_handoverService.Object);
            var response = await controller.GetHandover(key);
           
            Assert.IsType<OkObjectResult>(response.Result); 
            var value = (Handover)((OkObjectResult)response.Result).Value;
            Assert.True(key == value.patientKey);
        }
        [Fact]
        public async Task GetHandoverGroups()
        {
            _handoverService.Setup(s => s.GetHandoverGroups())
            .ReturnsAsync(_mockData.HandoverGroups);

            var controller = new HandoverController(_handoverService.Object);
            var response = await controller.GetHandoverGroups();
           
            Assert.IsType<OkObjectResult>(response.Result); 
            var value = (IEnumerable<HandoverGroup>)((OkObjectResult)response.Result).Value;
            Assert.True(_mockData.HandoverGroups.Count == value.Count());
        }
        [Fact]
        public async Task GetHandoverLog()
        {
            var mockData = _mockData.Handovers[2];
            _handoverService.Setup(s => s.GetHandoverLog(It.Is<string>(s => s == mockData.patientKey)))
            .ReturnsAsync(_mockData.HandoverLogs.Where(l => l.HandoverId == mockData.id));

            var controller = new HandoverController(_handoverService.Object);
            var response = await controller.GetHandoverLog(mockData.patientKey);
           
            Assert.IsType<OkObjectResult>(response.Result); 
            var value = (IEnumerable<HandoverLog>)((OkObjectResult)response.Result).Value;
            Assert.True(value.All(v => v.HandoverId == mockData.id));
        }
        [Fact]
        public async Task GetHandoverHistory()
        {
            var mockData = _mockData.Handovers[2];
            var mockLog = _mockData.HandoverLogs.FirstOrDefault(l => l.HandoverId == mockData.id);

            _handoverService.Setup(s => s.GetHandoverHistory(mockData.patientKey, mockLog.id))
            .ReturnsAsync(_mockData.Handovers[2]);

            var controller = new HandoverController(_handoverService.Object);
            var response = await controller.GetHandoverHistory(mockData.patientKey, mockLog.id);
           
            Assert.IsType<OkObjectResult>(response.Result); 
            var value = (Handover)((OkObjectResult)response.Result).Value;
            Assert.True(mockData.patientKey == value.patientKey);
        }
        [Fact]
        public async Task PostHandover_Add()
        {
            var mockData = _mockData.Handovers[2];
            _handoverService.Setup(s => s.AddHandover(mockData))
            .ReturnsAsync(mockData);
            _handoverService.Setup(s => s.HandoverExists(mockData.patientKey))
            .Returns(false);

            var controller = new HandoverController(_handoverService.Object);
            var response = await controller.PostHandover(mockData, 1);
            Assert.IsType<CreatedAtActionResult>(response.Result); 
            var value = (Handover)((CreatedAtActionResult)response.Result).Value;
            Assert.True(mockData.patientKey == value.patientKey);
        }
        [Fact]
        public async Task PostHandover_Update()
        {
            var mockData = _mockData.Handovers[2];
            _handoverService.Setup(s => s.UpdateHandover(mockData))
            .ReturnsAsync(mockData);
            _handoverService.Setup(s => s.HandoverExists(mockData.patientKey))
            .Returns(true);

            var controller = new HandoverController(_handoverService.Object);
            var response = await controller.PostHandover(mockData, 1);
            Assert.IsType<CreatedAtActionResult>(response.Result); 
            var value = (Handover)((CreatedAtActionResult)response.Result).Value;
            Assert.True(mockData.patientKey == value.patientKey);
        }
        [Fact]
        public async Task DeleteHandover()
        {
            var mockData = _mockData.Handovers[2];

             _handoverService.Setup(s => s.DeleteHandover(It.IsAny<Guid>(), It.IsAny<string>()));

            var controller = new HandoverController(_handoverService.Object);
            var response = await controller.DeleteHandover(mockData.id);
            Assert.IsType<NoContentResult>(response); 
        }
        [Fact]
        public async Task QueryHandover()
        {
            var mockData =  new QueryHandoverResponse(_mockData.Handovers[2]);

            _handoverService.Setup(s => s.QueryHandover(null, null, DateTime.MaxValue, null, null, 1, 1))
            .ReturnsAsync(new GridQueryResponse<QueryHandoverResponse>(){
              TotalRows = 1,
              Rows = new List<QueryHandoverResponse>(){ mockData}
            });        

            var controller = new HandoverController(_handoverService.Object);
            var response = await controller.QueryHandover(null, DateTime.MaxValue, null, null, 1, 1);

            Assert.IsType<OkObjectResult>(response.Result); 
            var value = (GridQueryResponse<QueryHandoverResponse>)((OkObjectResult)response.Result).Value;
            Assert.True(1 == value.Rows.Count());
            Assert.True(1 == value.TotalRows);
        }
    }
}