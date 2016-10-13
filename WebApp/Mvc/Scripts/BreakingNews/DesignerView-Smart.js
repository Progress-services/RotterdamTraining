angular.module('designer').requires.push('sfSelectors');

angular.module('designer')
    .controller('SmartCtrl', ['$scope', '$http', 'propertyService', function ($scope, $http, propertyService) {
        $scope.feedback.showLoadingIndicator = true;

        // Get widget properies and load them in the controller's scope
        propertyService.get()
            .then(function (data) {
                if (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);
                }
            }, function (data) {
                $scope.feedback.showError = true;

                if (data) {
                    $scope.feedback.errorMessage = data.Detail;
                }
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });

        $http.get('/api/default/newsitems?$filter=Tags/any(x:x eq 0dd81bd9-ac86-6d22-b705-ff0000413cd5)').then(function (response) {
            $scope.newsItems = response.data.value;
        });

        $scope.$watch('properties.SelectedNewsItem.PropertyValue', function (newValue, oldValue) {
            if (newValue) {
                $scope.SelectedNewsItem = JSON.parse(newValue);
            }
        });

        $scope.$watch('selectedItem', function (newValue, oldValue) {
            if (newValue) {
                $scope.properties.SelectedItem.PropertyValue = JSON.stringify(newValue);
            }
        });


        // Build breaking news message form Date and Message widget properties
        $scope.buildBreakingNewsMessage = function () {
            $scope.properties.BreakingNewsMessage.PropertyValue = $scope.properties.Title.PropertyValue;
        };
    }]);