angular.module('designer').requires.push('sfSelectors');

angular.module('designer')
    .controller('SimpleCtrl', ['$scope', '$http', 'propertyService', function ($scope, $http, propertyService) {
        $scope.feedback.showLoadingIndicator = true;

        $scope.$watch('webinarItems', function (newValue, oldValue) {
            if (newValue) {
                $scope.properties.WebinarItems.PropertyValue = JSON.stringify(newValue);
            }
        }, true);

        $scope.formatDate = function (date) {
            debugger
            var dateOut = new Date(date);
            return dateOut;
        };

        // Get widget properies and load them in the controller's scope
        propertyService.get()
            .then(function (data) {
                if (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);
                    $scope.webinarItems = JSON.parse($scope.properties.WebinarItems.PropertyValue);
                    // work on date format because of Angular. Dates are always complext in programming :)
                    //if ($scope.properties.EndDate.PropertyValue && !($scope.properties.EndTime.PropertyValue instanceof Date)) {
                    //    var endDate = $scope.properties.EndTime.PropertyValue;
                    //    $scope.properties.EndTime.PropertyValue = new Date(endDate.split('/')[2], endDate.split('/')[1] - 1, endDate.split('/')[0]);
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
    }]);