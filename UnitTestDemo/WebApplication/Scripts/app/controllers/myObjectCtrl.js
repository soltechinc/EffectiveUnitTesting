angular.module('myObjectCtrl', ['myObjectService']).
    controller('myObjectCtrl', ['$scope', 'myObjectService', function myObjectCtrl($scope, myObjectService) {
        $scope.list = [];
        $scope.query = function query() {
            myObjectService.query(null, function queryCallback(data) {
                $scope.list = data;
            });
        };
        $scope.deleteItem = function deleteItem(id) {
            $scope.error = false;
            $scope.errorMessage = null;
            myObjectService.delete({ 'id': id }, function deletionCallback(data) {
                $scope.error = !data.success;
                $scope.errorMessage = data.errorMessage;
            }, function deletionErrorCallback(error) {
                $scope.error = true;
                $scope.errorMessage = error.statusText;
            });
        };
        $scope.error = false;
        $scope.errorMessage = null;

        $scope.query();
    }]);