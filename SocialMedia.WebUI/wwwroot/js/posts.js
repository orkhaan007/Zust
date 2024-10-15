$(document).ready(function () {

    fetchPosts();

    $('#photoButton').on('click', function () {
        $('#image').click();
    });

    $('#postButton').on('click', function (e) {
        e.preventDefault();

        var formData = new FormData();
        formData.append('description', $('#description').val());
        var imageFile = $('#image')[0].files[0];

        if (imageFile) {
            formData.append('image', imageFile);
        }

        $.ajax({
            url: '/Home/CreatePost',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                $('#description').val('');
                $('#image').val('');

                appendNewPost(response);
            },
            error: function () {
                alert('Error while creating the post');
            }
        });
    });
});

function fetchPosts() {
    $.ajax({
        url: '/Home/GetPosts',
        type: 'GET',
        success: function (posts) {
            posts.forEach(function (post) {
                appendNewPost(post);
            });
        },
        error: function () {
            alert('Error fetching posts');
        }
    });
}

function appendNewPost(post) {
    const newsFeedArea = document.querySelector('.news-feed-area');

    console.log('Appending post:', post);

    let postHtml = `
        <div class="news-feed news-feed-post" id="post-${post.id}">
            <div class="post-header d-flex justify-content-between align-items-center">
                <div class="image">
                    <a href="my-profile.html"><img src="${post.userImageUrl}" style="width: 80px; height: 80px;" class="rounded-circle" alt="User image"></a>
                </div>
                <div class="info ms-3">
                    <span class="name"><a href="my-profile.html">${post.userName}</a></span>
                    <span class="small-text"><a href="#">${post.createdAt}</a></span>
                </div>
                <div class="dropdown">
                    <button class="dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="flaticon-menu"></i></button>
                    <ul class="dropdown-menu">
                        <li><a class="dropdown-item d-flex align-items-center edit-post" href="#" data-post-id="${post.id}"><i class="flaticon-edit"></i> Edit Post</a></li>
                        <li><a class="dropdown-item d-flex align-items-center hide-post" href="#" data-post-id="${post.id}"><i class="flaticon-private"></i> Hide Post</a></li>
                        <li><a class="dropdown-item d-flex align-items-center delete-post" href="#" data-post-id="${post.id}"> <i class="flaticon-trash"></i> Delete Post </a></li>

                    </ul>
                </div>
            </div>
            <div class="post-body">
                <p>${post.description}</p>
                ${post.imageUrl ? `<div class="post-image"><img src="${post.imageUrl}" alt="Post image"></div>` : ''}
                <ul class="post-meta-wrap d-flex justify-content-between align-items-center">
                    <li class="post-react">
                        <a href="#"><i class="flaticon-like"></i><span>Like</span></a>
                    </li>
                    <li class="post-comment">
                        <a href="#"><i class="flaticon-comment"></i><span>Comment</span></a>
                    </li>
                    <li class="post-share">
                        <a href="#" class="share-post" data-image-url="${post.imageUrl}"><i class="flaticon-share"></i><span>Share</span></a>
                    </li>
                </ul>
            </div>

        </div>
    `;

    newsFeedArea.insertAdjacentHTML('beforeend', postHtml);

    const shareButton = newsFeedArea.querySelector(`#post-${post.id} .share-post`);
    shareButton.addEventListener('click', function (event) {
        event.preventDefault();
        if (post.imageUrl) {
            navigator.clipboard.writeText(post.imageUrl).then(function () {
                alert('Image URL copied to clipboard!');
            }, function (err) {
                console.error('Could not copy text: ', err);
            });
        } else {
            alert('No image to share.');
        }
    });
}

$(document).on('click', '.delete-post', function (e) {
    e.preventDefault();

    var postId = $(this).data('post-id');

    if (confirm('Are you sure you want to delete this post?')) {
        $.ajax({
            url: `/Home/DeletePost/${postId}`,
            type: 'DELETE',
            success: function () {
                $(`#post-${postId}`).remove();
            },
            error: function () {
                alert('Error deleting the post');
            }
        });
    }
});


$(document).on('click', '.hide-post', function (e) {
    e.preventDefault();

    var postId = $(this).data('post-id');

    $.ajax({
        url: `/Home/HidePost/${postId}`,
        type: 'PATCH',
        success: function () {
            $(`#post-${postId}`).hide();
        },
        error: function () {
            alert('Error hiding the post');
        }
    });
});

$(document).on('click', '.edit-post', function (e) {
    e.preventDefault();

    var postId = $(this).data('post-id');
    var newDescription = prompt('Enter new description:');

    if (newDescription) {
        $.ajax({
            url: `/Home/EditPost/${postId}`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify({ description: newDescription }),
            success: function (response) {
                $(`#post-${postId} .post-body p`).text(response.description);
            },
            error: function () {
                alert('Error editing the post');
            }
        });
    }
});