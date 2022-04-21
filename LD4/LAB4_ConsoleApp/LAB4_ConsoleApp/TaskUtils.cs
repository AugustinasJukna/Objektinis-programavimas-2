using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_ConsoleApp
{
    public static class TaskUtils
    {
        public static int FindGuidesCount(LinkList<FileData> filesList)
        {
            int count = 0;
            try
            {
                foreach (FileData file in filesList)
                {
                    foreach (Location location in file.Locations)
                    {
                        if (location is Museum && ((Museum)location).HasGuide) count++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Argument is null", ex);
            }
            return count;
        }

        public static Location OldestLocation(LinkList<FileData> files)
        {
            Location oldest = new Statue("", "", DateTime.Now.Year, "", "");
            try
            {
                foreach (FileData file in files)
                {
                    foreach (Location location in file.Locations)
                    {
                        if (oldest.YearFounded > location.YearFounded)
                        {
                            oldest = location;
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Argument is null", ex);
            }
            return oldest;
        }

        public static LinkList<Location> FilterNewLocations(LinkList<FileData> files)
        {
            LinkList<Location> filtered = new LinkList<Location>();
            int currentYear = DateTime.Now.Year;

            try
            {
                foreach (FileData file in files)
                {
                    foreach (Location location in file.Locations)
                    {
                        switch (location)
                        {
                            case Museum museum:
                                if (currentYear - museum.YearFounded < 2) filtered.Add(museum);
                                break;
                            case Statue statue:
                                if (currentYear - statue.YearFounded <= 1) filtered.Add(statue);
                                break;
                        }
                    } 
                }
            }
            catch (Exception)
            {
                throw;
            }  

            return filtered;
        }
    }
}
