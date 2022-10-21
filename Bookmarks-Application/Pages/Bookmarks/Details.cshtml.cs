﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bookmarks_Application.Data;
using Bookmarks_Application.Data.Models;

namespace Bookmarks_Application.Pages.Bookmarks
{
    public class DetailsModel : PageModel
    {
        private readonly Bookmarks_Application.Data.AppDbContext _context;

        public DetailsModel(Bookmarks_Application.Data.AppDbContext context)
        {
            _context = context;
        }

      public Bookmark Bookmark { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookmarks == null)
            {
                return NotFound();
            }

            var bookmark = await _context.Bookmarks.FirstOrDefaultAsync(m => m.Id == id);
            if (bookmark == null)
            {
                return NotFound();
            }
            else 
            {
                Bookmark = bookmark;
            }
            return Page();
        }
    }
}
