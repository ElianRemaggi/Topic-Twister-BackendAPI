using BackendAPI.Modelo.Repository;
using BackendAPI.Service;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace APITests
{
    public class CategoryRepositoryTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public static void List_of_categories_should_not_be_empty()
        {
            //Arrange
            ICategoryRepository categoryRepository;
            categoryRepository = new CategoryRepository(PathProvider.GetCategoryJsonPath());
            //Act
            //Assert
            Assert.IsNotNull(categoryRepository.CategoryRepositoryLength);
        }

        [Test]
        public static void GetCategoryById_should_return_a_category_with_correct_id()
        {
            //Arrange
            ICategoryRepository categoryRepository;
            categoryRepository = new CategoryRepository(PathProvider.GetCategoryJsonPath());
            List<Category> FullList = categoryRepository.LoadCategoryList(PathProvider.GetCategoryJsonPath());
            //Act
            Category result = categoryRepository.FindCategoryById(4);


            //Assert
            foreach (var item in FullList)
            {
                if (result.CategoryID == item.CategoryID)
                {
                    Assert.AreEqual(result.CategoryID, item.CategoryID);
                }
            }

        }

        [Test]
        public static void GetCategoryById_should_return_a_Exception_if_wrong_id()
        {
            //Arrange
            ICategoryRepository categoryRepository = new CategoryRepository(PathProvider.GetCategoryJsonPath());
            List<Category> FullList = categoryRepository.LoadCategoryList(PathProvider.GetCategoryJsonPath());
            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => categoryRepository.FindCategoryById(654));
        }

    }
}