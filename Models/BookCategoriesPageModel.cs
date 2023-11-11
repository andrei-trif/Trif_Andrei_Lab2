﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Trif_Andrei_Lab2.Data;

namespace Trif_Andrei_Lab2.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList = new List<AssignedCategoryData>();

        public void PopulateAssignedCategoryData(Trif_Andrei_Lab2Context context, Book book)
        {
            var allCategories = context.Category;

            var bookCategories = book.BookCategories != null 
                ? new HashSet<int>(book.BookCategories.Select(c => c.CategoryID))
                : new HashSet<int>();

            AssignedCategoryDataList = new List<AssignedCategoryData>();

            if (allCategories != null)
            {
                foreach (var cat in allCategories)
                {
                    AssignedCategoryDataList.Add(new AssignedCategoryData
                    {
                        CategoryID = cat.ID,
                        Name = cat.CategoryName,
                        Assigned = bookCategories.Contains(cat.ID)
                    });
                }
            }       
        }

        public void UpdateBookCategories(Trif_Andrei_Lab2Context context, string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = bookToUpdate.BookCategories != null 
                ? new HashSet<int>(bookToUpdate.BookCategories.Select(c => c.Category.ID))
                : new HashSet<int>();

            if (context.Category == null) return;
            
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.BookCategories?.Add(
                        new BookCategory
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        var courseToRemove = bookToUpdate.BookCategories?.SingleOrDefault(i => i.CategoryID == cat.ID);
                        if (courseToRemove is not null) context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
