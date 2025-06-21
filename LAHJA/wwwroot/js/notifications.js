window.signalRHelper = {
    connection: null,

    initializeSignalR: function () {
        if (!this.connection) {
            this.connection = new signalR.HubConnectionBuilder()
                .withUrl("/notificationHub", {
                    accessTokenFactory: async () => {
                        return localStorage.getItem("accessToken"); // التأكد من أن التوكن موجود
                    }
                })
                .build();

            this.connection.on("ReceiveNotification", (message) => {
                alert("إشعار جديد: " + message);
            });

            this.connection.start()
                .then(() => console.log("✅ SignalR Connected."))
                .catch(err => console.error("❌ SignalR Connection Failed: ", err));
        }
    }
};

window.signalRHelper.initializeSignalR()
