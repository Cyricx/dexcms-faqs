define([
   'controlpanel-app',
   '../faqitems/index'
], function (app) {
    app.controller('faqCategoriesListCtrl', [
        '$scope',
        'FaqCategories',
        '$stateParams',
        '$state',
        function ($scope, FaqCategories, $stateParams, $state) {
            $scope.title = "Faqs";
            $scope.selectedCategory = null;

            var buildFaqCategories = function (isInit) {
                FaqCategories.getList($stateParams.id).then(function (response) {
                    $scope.faqCategories = response;
                    if (isInit && $scope.faqCategories.length > 0) {
                        $scope.selectCategory($scope.faqCategories[0]);
                    }
                });
            };

            var init = function () {
                buildFaqCategories(true);

            };

            init();

            $scope.$on('faqItemCountChanged', function (event, data) {
                buildFaqCategories();
            })

            $scope.isAdding = false;

            $scope.openAddCategory = function () {
                $scope.isAdding = true;
                $scope.newCategory = { displayOrder: 0, isActive: true, faqSectionID: 1 };
            };

            $scope.clearAddCategory = function () {
                $scope.isAdding = false;
                delete $scope.newCategory;
            };

            $scope.saveCategory = function (category) {
                $scope.isProcessing = true;
                category.eventID = $stateParams.id;
                FaqCategories.createItem(category).then(function (response) {
                    buildFaqCategories();
                    $scope.clearAddCategory();
                    $scope.isProcessing = false;
                    $scope.selectCategory(response);
                });
            };

            $scope.deleteCategory = function (category) {
                if (confirm('Are you sure?')) {
                    if (category.faqCategoryID == $scope.selectedCategory.faqCategoryID) {
                        $scope.selectCategory = null;
                    }
                    FaqCategories.deleteItem(category.faqCategoryID).success(function () {
                        $scope.faqCategories.splice($scope.faqCategories.indexOf(category), 1);
                    });
                }
            };

            $scope.openEditCategory = function (category) {
                category.isEditting = true;
            };

            $scope.closeEditCategory = function (category) {
                category.isEditting = false;
            };

            $scope.updateCategory = function (category) {
                category.isProcessing = true;
                FaqCategories.updateItem(category.faqCategoryID, category).then(function () {
                    category.isProcessing = false;
                    $scope.closeEditCategory(category);
                });
            }

            $scope.dropCategoryCallback = function (event, index, item) {
                $scope.pendingCategoryOrder = true;
                return item;
            };

            $scope.saveCategoryOrder = function () {
                $scope.updateProcessing = true;
                var doneCount = $scope.faqCategories.length;
                var updateCount = 0;
                var index = 0;
                angular.forEach($scope.faqCategories, function (value) {
                    value.displayOrder = index;
                    index++;
                    FaqCategories.updateItem(value.faqCategoryID, value).then(function () {
                        updateCount++;
                        if (updateCount === doneCount) {
                            $scope.updateProcessing = false;
                            $scope.pendingCategoryOrder = false;
                        }
                    })
                })

            };

            $scope.selectCategory = function (category) {
                $scope.selectedCategory = category;
            }
            $scope.getClass = function (cat) {
                var cssClass = "";

                if (cat.faqCategoryID == $scope.selectedCategory.faqCategoryID) {
                    cssClass = "list-group-item-primary"
                } else {
                    cssClass = "list-group-item-info";
                }

                return cssClass;
            }
        }
    ]);
});