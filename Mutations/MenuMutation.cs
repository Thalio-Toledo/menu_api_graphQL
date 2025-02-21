using MenuGraphQl_API.Database;
using MenuGraphQl_API.Entities;

namespace MenuGraphQl_API.Mutations
{
    public class MenuMutation
    {
        public Menu AddMenu([Service] DataContext context, Menu menu) 
        {
            context.Menu.Add(menu);
            context.SaveChanges();
            return menu;
        }

        public Menu UpdateMenu([Service] DataContext context, Menu menu)
        {
            context.Menu.Update(menu);
            context.SaveChanges();
            return menu;
        }
        public bool DeleteMenu([Service] DataContext context, int id)
        {
            var menu = context.Menu.FirstOrDefault(m => m.Id == id);
            if (menu is null) return false;
            context.Menu.Remove(menu);
            return context.SaveChanges() > 0;
        }
    }
}
