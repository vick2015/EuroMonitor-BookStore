using System;
using System.Collections.Generic;

using BookStore.Models;


namespace BookStore.Stores
{

    public class Users 
    {
        public static List<UserEntity> GetValidUserEntities()
        {
            var user = new UserEntity {UserId = Guid.Parse("301df04d-8679-4b1b-ab92-0a586ae53d08"), Email = "test", Password = "test" };
            return new List<UserEntity>() {user};
        }
    }
}
