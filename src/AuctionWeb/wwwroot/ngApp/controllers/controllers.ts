namespace AuctionWeb.Controllers {

    export class HomeController {
        public items;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService) {
            $http.get('api/items').then((res) => {
                this.items = res.data;
            });
        }

        public post(item) {
            this.$http.post('api/items', item).then((res) => {
                this.$state.reload();
            });
        }
        public delete(itemId) {
            this.$http.delete(`api/items/${itemId}`).then((res => {
                this.$state.reload();
            }));
        }
    }


    export class DetailsController {
        public item;


        constructor(public $http: ng.IHttpService, public $stateParams: ng.ui.IStateParamsService,
            public $state: ng.ui.IStateService) {
            $http.get(`api/items/${$stateParams['id']}`).then((res) => {
                this.item = res.data;
                console.log(this.item);
            });
        }

        public addCustomer(customer) {
            //alternate
            //console.log("customer" + customer);
            //if (this.item.customers == null) {
            //    this.item.customers = [];
            //}
            //this.item.customers.push(customer);

           
            //console.log(this.$state);

            this.$http.post(`api/items/${this.$stateParams['id']}`, customer).then((res) => {
                this.$state.reload();
            });

        }

        public deleteCustomer(customer) {
            this.$http.delete(`api/items/${this.$stateParams['id']}`, customer).then((res) => {
                console.log(res);
                this.$state.reload();
            }).catch((err) => {
                console.log(err);
            });
        }

    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
