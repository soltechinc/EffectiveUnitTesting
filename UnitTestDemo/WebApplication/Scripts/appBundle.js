///#source 1 1 /Scripts/app/app.js
angular.module("app", ['myObjectModule']);
///#source 1 1 /Scripts/app/controllers/myObjectCtrl.js
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
///#source 1 1 /Scripts/app/modules/myObjectModule.js
angular.module('myObjectModule', [
    'myObjectCtrl', 'myObjectService'
]);
///#source 1 1 /Scripts/app/services/myObjectService.js
angular.module('myObjectService', ['ngResource'])
    .factory('myObjectService', ['$resource', function myObjectService($resource) {
        return $resource('/MyObject/:id',
            null,
            {
                'get': {'method': 'GET'},
                'delete': {'method': 'DELETE'},
                'query': { method: 'GET', isArray: true }
            });
    }
]);
