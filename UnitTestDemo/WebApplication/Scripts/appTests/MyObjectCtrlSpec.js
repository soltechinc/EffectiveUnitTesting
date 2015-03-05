/// <reference path="../jasmine/jasmine.js" />
/// <reference path="../angular.js" />
/// <reference path="../angular-resource.js" />
/// <reference path="../angular-mocks.js" />

/// <reference path="../appBundle.js" />

describe("MyObjectCtrl", function () {
    
    var $controller;
    var $scope;
    var $httpBackend;
    beforeEach(module('app'));

    beforeEach(inject(function (_$controller_, _$rootScope_, _$httpBackend_) {
        try
        {
            $controller = _$controller_;
            $scope = _$rootScope_.$new();
            $httpBackend = _$httpBackend_;
        } catch (e)
        {
            console.log(e);
        }
    }));

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
    });

    it("Verify math works", function () {
        var operand1 = 1;
        var operand2 = 1;
        expect(operand1 + operand2).toBe(2);
    });

    //it("The controller should fetch objects from the backend upon creation.", function () {
        
    //    $httpBackend.expectGET(/^\/MyObject/).respond(function handleGetMyObject(method, url, data, headers) {
    //        return [200, [
    //            {
    //                'id': '00000000-0000-0000-000000000000',
    //                'name': 'Test object',
    //                'created': '2015-03-04T05:00:00Z'
    //            },
    //            {
    //                'id': '00000000-0000-0000-000000000000',
    //                'name': 'Test object',
    //                'created': '2015-03-04T15:01:00Z'
    //            }], {}, 'OK'];
    //    });
    //    myObjectCtrl = $controller('myObjectCtrl', { '$scope': $scope });
    //    $httpBackend.flush();
    //    expect($scope.list).not.toBeUndefined();
    //    expect($scope.list).not.toBeNull();
    //    expect($scope.list.length).toBe(2);
    //});

    //it("The controller should call DELETE on the service when delete() is called.", function () {
    //    $httpBackend.expectGET(/^\/MyObject/).respond([200, [], {}, "OK"]);
    //    $httpBackend.expectDELETE(/^\/MyObject\/1/).respond(function handleDeleteMyObject(method, url, data, headers) {
    //        return [200, {'success': true}, {}, 'OK'];
    //    });
    //    myObjectCtrl = $controller('myObjectCtrl', { '$scope': $scope });
    //    $scope.deleteItem(1);
    //    $httpBackend.flush();
    //});

    //it("The controller should set 'error' to false when deletion succeeds.", function () {
    //    $httpBackend.expectGET(/^\/MyObject/).respond([200, [], {}, "OK"]);
    //    $httpBackend.expectDELETE(/^\/MyObject\/1/).respond(function handleDeleteMyObject(method, url, data, headers) {
    //        return [200, { 'success': true }, {}, 'OK'];
    //    });
    //    myObjectCtrl = $controller('myObjectCtrl', { '$scope': $scope });
    //    $scope.deleteItem(1);
    //    $httpBackend.flush();
    //    expect($scope.error).toBe(false);
    //});

    //it("The controller should set 'error' to true and 'errorMessage' to the message when deletion fails.", function () {
    //    $httpBackend.expectGET(/^\/MyObject/).respond([200, [], {}, "OK"]);
    //    $httpBackend.expectDELETE(/^\/MyObject\/1/).respond(function handleDeleteMyObject(method, url, data, headers) {
    //        return [200, { 'success': false, 'errorMessage': 'Mock error.' }, {}, 'OK'];
    //    });
    //    myObjectCtrl = $controller('myObjectCtrl', { '$scope': $scope });
    //    $scope.deleteItem(1);
    //    $httpBackend.flush();
    //    expect($scope.error).toBe(true);
    //    expect($scope.errorMessage).toBe('Mock error.');
    //});

    //it("The controller should set 'error' to true and 'errorMessage' to 'An invalid response was returned from the server.' when deletion returns an unexpected result.", function () {
    //    $httpBackend.expectGET(/^\/MyObject/).respond([200, [], {}, "OK"]);
    //    $httpBackend.expectDELETE(/^\/MyObject\/foo/).respond(function handleDeleteMyObject(method, url, data, headers) {
    //        return [400, '', {}, 'Bad Request'];
    //    });
    //    myObjectCtrl = $controller('myObjectCtrl', { '$scope': $scope });
    //    $scope.deleteItem('foo');
    //    $httpBackend.flush();
    //    expect($scope.error).toBe(true);
    //    expect($scope.errorMessage).toBe('Bad Request');
    //});
});
