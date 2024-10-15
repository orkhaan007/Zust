// sending request and updating the contacts aside container : 
function sendRequestAndUpdateContacts(key) {
    $.ajax({
        url:  "https://localhost:7220/Account/GetAllUsers",
        method: "GET",
        data: {
            key : key,
        },
        success: function (response) {
            let allUsers = response.allUsers;
            let content = "";
            for (let i = 0; i < allUsers.length; i++) {
                let item = `
                <div class="contact-item">
                    <a href="#">
                        <img src="${allUsers[i].imageUrl}" class="rounded-circle" alt="image" />
                    </a>
                    <span class="name"><a href="#">${allUsers[i].userName}</a></span>
                    <span class="${allUsers[i].isOnline ? 'status-online' : 'status-offline'}"></span>
                </div>
                `;
                content += item;
            }
            $("#contacts").html(content);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Failed to send requst to the /Account/GetAllUsers .");
            console.error('Error:', textStatus, errorThrown);
        }
    });
}

const searchContact = document.getElementById("searchContact");
searchContact.addEventListener("input", () => {
    sendRequestAndUpdateContacts(searchContact.value);
});

document.getElementById("coverImageInput").addEventListener("change", function () {
    var formData = new FormData();
    formData.append("file", this.files[0]);

    $.ajax({
        url: '/api/upload-cover-image',
        type: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: function (response) {
            var imageUrl = response.imageUrl;

            $('#myProfileBgImage').attr('src', imageUrl);

            console.log("Image uploaded and updated successfully.");
        },
        error: function () {
            console.log("Image upload failed.");
        }
    });
});