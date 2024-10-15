const connection = new signalR.HubConnectionBuilder()
    .withUrl("/zustHub")
    .build();

connection.start()
    .then(() => {
        console.log("SignalR connection established");
    })
    .catch(err => console.error("SignalR connection failed: ", err));

connection.on("UpdateContacts", async() => {
    await updateMyProfileView();
    updateIndexView();
    sendRequestAndUpdateContacts("");
    updateLayoutView();
    updateChats();
});

connection.on("UpdateAllMessages", (senderId) => {
    updateMessages(senderId);
    updateLayoutView();
});

connection.on("UpdateNotificationsForReceiver", () => {
    updateNotifications();
});

connection.on("UpdateFriendRequestsAndFriends", async() => {
    updateLayoutView();
    updateIndexView();
    await updateSettingView();
    await updateAllAboutFriends();
});