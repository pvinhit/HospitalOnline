using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Filters
{
	public class PagedList<T> : List<T>
	{
		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			Page = new Page
			{
				//tong so phan tu
				TotalCount = count,
				//kich thuoc trang
				PageSize = pageSize,
				//trang hien tai
				CurrentPage = pageNumber,
				//tong so trang = tong so phan tu / kich thuoc trang
				TotalPages = (int)Math.Ceiling(count / (double)pageSize)
			};
			AddRange(items);
		}
		public Page Page { get; set; }

		public static async Task<PagedList<T>> ToPagedList(IQueryable<T> query, int pageNumber, int pageSize)
		{
			var count = await query.CountAsync();
			//chi so bat dau la bang tong so trang -1 * pageSize
			//chi so ket thuc la 
			var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
			//Phần tử bắt đầu của mỗi trang = (trang_hiện_tại - 1) * số_phần_tử_mỗi_trang + 1

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}
