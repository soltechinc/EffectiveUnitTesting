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