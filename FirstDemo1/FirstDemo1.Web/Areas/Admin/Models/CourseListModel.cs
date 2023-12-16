﻿using FirstDemo.Infrastructure;
using FirstDemo1.Domain.Features.Training;
using System.Web;

namespace FirstDemo1.Web.Areas.Admin.Models
{
    public class CourseListModel
    {
        private readonly ICourseManagementService _courseService;

        public CourseListModel()
        {
        }

        public CourseListModel(ICourseManagementService courseService)
        {
            _courseService = courseService;
        }


        public async Task<object> GetPagedCoursesAsync(DataTablesAjaxRequestUtility dataTablesUtility)
        {
            var data = await _courseService.GetPagedCoursesAsync(
                dataTablesUtility.PageIndex,
                dataTablesUtility.PageSize,
                dataTablesUtility.SearchText,
                dataTablesUtility.GetSortText(new string[] { "Title", "Fees" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                HttpUtility.HtmlEncode(record.Title),
                                HttpUtility.HtmlEncode(record.Description),
                                record.Fees.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
