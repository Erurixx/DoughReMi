// JavaScript source code
let timeoutId;

function showContent(contentId) {
    // Hide all audience-content divs
    const contents = document.querySelectorAll('.audience-content');
    contents.forEach(content => {
        content.style.display = 'none';
    });

    // Show the selected content
    const selectedContent = document.getElementById(contentId);
    if (selectedContent) {
        selectedContent.style.display = 'flex';
    }
}

// Function to show profile dropdown
function showProfileDropdown() {
    clearTimeout(timeoutId); // Clear any existing timeout
    const profileDropdown = document.getElementById('profile-dropdown');
    if (profileDropdown) {
        profileDropdown.style.display = 'block';
    }
}

// Function to hide profile dropdown with delay
function hideProfileDropdown() {
    timeoutId = setTimeout(() => {
        const profileDropdown = document.getElementById('profile-dropdown');
        if (profileDropdown) {
            profileDropdown.style.display = 'none';
        }
    }, 150); // Adjust delay duration as needed (500 milliseconds in this example)
}

// Clear timeout to prevent hiding dropdown if mouse re-enters quickly
function clearHideProfileDropdown() {
    clearTimeout(timeoutId);
}

// By default, show the 'parents-kids' content
document.addEventListener('DOMContentLoaded', () => {
    showContent('parents-kids');
});

// Show profile dropdown on mouseover
document.querySelector('.profile').addEventListener('mouseover', showProfileDropdown);

// Hide profile dropdown on mouseout with delay
document.getElementById('profile-dropdown').addEventListener('mouseout', hideProfileDropdown);

// Clear timeout if mouse re-enters profile area quickly
document.querySelector('.profile').addEventListener('mouseover', clearHideProfileDropdown);
