define([
   'controlpanel-app'
], function (module) {
    module.directive('dexcmsFaqItemsList', [
        'dexCMSControlPanelSettings',
        function (dexcmsSettings) {

            return {
                restrict: "E",
                scope: {
                    "faqCategory": "="
                },
                templateUrl: dexcmsSettings.startingRoute + '/modules/faqs/faqitems/_faqitems.list.html',
                controller: [
        '$scope',
        'FaqItems',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, FaqItems, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = null;
            $scope.faqItems = [];

            var buildFaqItems = function () {
                if ($scope.category) {
                    FaqItems.getListByFaqCategory($scope.category.faqCategoryID).then(function (response) {
                        $scope.faqItems = response;
                    });
                } else {
                    delete $scope.faqItems;
                }
            };
            var buildTitle = function () {
                if ($scope.category) {
                    $scope.title = $scope.category.name + " Items";
                } else {
                    $scope.title = "Please select a category.";
                }
            }
            $scope.$watch(function ($scope) {
                return $scope.faqCategory;
            }, function (newVal) {
                $scope.isAdding = false;
                $scope.category = newVal;
                buildFaqItems();
                buildTitle();
            })

            $scope.isAdding = false;

            $scope.openAddFaqItem = function () {
                $scope.isAdding = true;
                $scope.newFaqItem = { displayOrder: 0, isActive: true };
            };

            $scope.clearAddFaqItem = function () {
                $scope.isAdding = false;
                delete $scope.newFaqItem;
            };

            $scope.saveFaqItem = function (faqItem) {
                faqItem.faqCategoryID = $scope.category.faqCategoryID;
                $scope.isProcessing = true;
                FaqItems.createItem(faqItem).then(function (response) {
                    buildFaqItems();
                    $scope.clearAddFaqItem();
                    $scope.isProcessing = false;
                    $scope.$emit('faqItemCountChanged', true);
                });
            };

            $scope.deleteFaqItem = function (faqItem) {
                if (confirm('Are you sure?')) {
                    FaqItems.deleteItem(faqItem.faqItemID).success(function () {
                        $scope.faqItems.splice($scope.faqItems.indexOf(faqItem), 1);
                        $scope.$emit('faqItemCountChanged', true);
                    });
                }
            };

            $scope.openEditFaqItem = function (faqItem) {
                faqItem.isEditting = true;
            };

            $scope.closeEditFaqItem = function (faqItem) {
                faqItem.isEditting = false;
            };

            $scope.updateFaqItem = function (faqItem) {
                faqItem.isProcessing = true;
                FaqItems.updateItem(faqItem.faqItemID, faqItem).then(function () {
                    faqItem.isProcessing = false;
                    if (faqItem.resetMarks) {
                        faqItem.helpfulMarks = null;
                        faqItem.unhelpfulMarks = null;
                        faqItem.resetMarks = false;
                    }
                    $scope.closeEditFaqItem(faqItem);
                });
            }

            $scope.dropFaqItemCallback = function (event, index, item) {
                $scope.pendingFaqItemOrder = true;
                return item;
            };

            $scope.saveFaqItemOrder = function () {
                $scope.updateProcessing = true;
                var doneCount = $scope.faqItems.length;
                var updateCount = 0;
                var index = 0;
                angular.forEach($scope.faqItems, function (value) {
                    value.displayOrder = index;
                    index++;
                    FaqItems.updateItem(value.faqItemID, value).then(function () {
                        updateCount++;
                        if (updateCount === doneCount) {
                            $scope.updateProcessing = false;
                            $scope.pendingFaqItemOrder = false;
                        }
                    })
                })

            }



        }
                ]
            }


        }
    ]);
});