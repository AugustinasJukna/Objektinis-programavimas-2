using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_WebApp
{
    public static class TaskUtils
    {
        /// <summary>
        /// Finds guides count throughout all lists
        /// </summary>
        /// <param name="filesList"></param>
        /// <returns></returns>
        public static int FindGuidesCount(LinkList<FileData> filesList)
        {
            int count = 0;
            try
            {
                foreach (FileData file in filesList)
                {
                    foreach (Location location in file.GetLocationsList())
                    {
                        if (location is Museum && ((Museum)location).HasGuide) count++;
                    }
                }
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
            return count;
        }

        /// <summary>
        /// Finds the oldest location in all of the lists
        /// </summary>
        /// <param name="files">All files list</param>
        /// <returns>oldest location</returns>
        public static Location OldestLocation(LinkList<FileData> files)
        {
            Location oldest = new Statue("", "", DateTime.Now.Year, "", "");
            try
            {
                foreach (FileData file in files)
                {
                    foreach (Location location in file.GetLocationsList())
                    {
                        if (oldest.YearFounded > location.YearFounded)
                        {
                            oldest = location;
                        }
                    } 
                }
                if (oldest == new Statue("", "", DateTime.Now.Year, "", "")) oldest = null;
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
            return oldest;
        }

        /// <summary>
        /// Filters new locations to a new list
        /// </summary>
        /// <param name="files">list of all files</param>
        /// <returns>LinkList of Location type, made out of new locations</returns>
        public static LinkList<Location> FilterNewLocations(LinkList<FileData> files)
        {
            LinkList<Location> filtered = new LinkList<Location>();
            int currentYear = DateTime.Now.Year;
            try
            {
                foreach (FileData file in files)
                {
                    foreach (Location location in file.GetLocationsList())
                    {
                        if (location.IsNew())
                        {
                            filtered.Add(location);
                        }
                    } 
                }
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }  

            return filtered;
        }

        /// <summary>
        /// Merges all lists out of all the files into one Location list
        /// </summary>
        /// <param name="files">all files list</param>
        /// <returns>Location class link list</returns>
        public static LinkList<Location> MergeLists(LinkList<FileData> files)
        {
            LinkList<Location> all = new LinkList<Location>();
            try
            {
                foreach (FileData file in files)
                {
                    foreach (Location location in file.GetLocationsList())
                    {
                        all.Add(location);
                    }
                }
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }

            return all;
        }
    }
}
