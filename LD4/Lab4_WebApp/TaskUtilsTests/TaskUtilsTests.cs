using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Lab4_WebApp;

namespace TaskUtilsTests
{
    public class TaskUtilsTests
    {
        LinkList<Location> locations;
        LinkList<FileData> files;
        int[] array = { 0, 1, 1, 0, 1, 1, 1 };

        [Fact]
        public void ShouldBeGuidesCountZero()
        {
            int result = 0;
            locations = new LinkList<Location>();
            locations.Add(new Museum("", "", 0, "", array, false, 0));
            locations.Add(new Museum("", "", 1, "", array, false, 1));
            LinkList<FileData> files = new LinkList<FileData>();
            FileData file = new FileData("", "", locations, "");


            Assert.Equal(TaskUtils.FindGuidesCount(files), result);
        }

        [Fact]
        public void ShouldThrowNullReferenceException()
        {
            LinkList<FileData> files = null;

            Assert.Throws<NullReferenceException>(() => TaskUtils.FindGuidesCount(files));
        }

        [Theory]
        [InlineData(1200)]
        [InlineData(1900)]
        [InlineData(1949)]
        public void ShouldFindTheOldestLocation(int oldestYear)
        {
            int result = oldestYear;
            LinkList<FileData> files = new LinkList<FileData>();

            locations = new LinkList<Location>();
            locations.Add(new Statue("", "", 1950, "", ""));
            locations.Add(new Statue("", "", oldestYear, "", ""));
            locations.Add(new Museum("", "", 1996, "", array, false, 0));

            files.Add(new FileData("", "", locations, ""));

            Assert.Equal(result, TaskUtils.OldestLocation(files).YearFounded);

        }

        [Fact]
        public void ShouldFilterNewLocations()
        {
            int result = 2021;
            files = new LinkList<FileData>();
            locations = new LinkList<Location>();

            locations.Add(new Statue("", "", 2020, "", ""));
            locations.Add(new Statue("", "", 2021, "", ""));
            locations.Add(new Statue("", "", 2018, "", ""));

            files.Add(new FileData("", "", locations, ""));

            Assert.True(TaskUtils.FilterNewLocations(files).Get(0).YearFounded == result && TaskUtils.FilterNewLocations(files).Count() == 1);
        }

        [Fact]
        public void ShouldNotFilterNewLocations()
        {
            files = new LinkList<FileData>();
            locations = new LinkList<Location>();

            locations.Add(new Statue("", "", 2020, "", ""));
            locations.Add(new Statue("", "", 2019, "", ""));
            locations.Add(new Statue("", "", 2018, "", ""));
            locations.Add(new Museum("", "", 2000, "", array, true, 0));

            files.Add(new FileData("", "", locations, ""));

            Assert.True(TaskUtils.FilterNewLocations(files).Count() == 0);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(3)]
        public void ShouldMergeTwoLists(int n)
        {
            int result = n * 2;

            LinkList<FileData> files = new LinkList<FileData>();
            int count = 0;
            while (count < 2)
            {
                locations = new LinkList<Location>();
                for (int i = 0; i < n; i++)
                {
                    locations.Add(new Statue("", "", 0, "", ""));
                }
                files.Add(new FileData("", "", locations, ""));
                count++;
            }

            Assert.Equal(result, TaskUtils.MergeLists(files).Count());
        }
    }
}
