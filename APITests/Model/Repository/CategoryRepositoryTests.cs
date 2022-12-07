using BackendAPI.Modelo.Repository;
using BackendAPI.Service;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace APITests.Repository
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
            List<Category> FullList = categoryRepository.LoadCategoryList();
            //Assert

            Assert.Throws<Exception>(() => categoryRepository.FindCategoryById(4));

        }

        [Test]
        public static void GetCategoryById_should_return_a_Exception_if_wrong_id()
        {
            //Arrange
            ICategoryRepository categoryRepository = new CategoryRepository(PathProvider.GetCategoryJsonPath());
            List<Category> FullList = categoryRepository.LoadCategoryList();
            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => categoryRepository.FindCategoryById(654));
        }

    }
}