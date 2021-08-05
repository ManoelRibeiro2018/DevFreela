using DevFreela.Core.Entites;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core
{
    public class ProjectTests
    {

        [Fact]
        public void TestIfProjectStartWork()
        {
            var project = new Project("title project", "Description project", 1, 1, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);


            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);


        }
    }
}
