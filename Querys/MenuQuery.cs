using HotChocolate;
using MenuGraphQl_API.Database;
using MenuGraphQl_API.Entities;
using System;

namespace MenuGraphQl_API.Querys
{
    public class MenuQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Menu> GetMenus([Service] DataContext context) => context.Menu;

        [UseProjection]
        public Menu? GetMenuById([Service] DataContext context, int id)
        {
            return context.Menu.FirstOrDefault(m => m.Id == id);
        }
    }
}
