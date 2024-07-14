let timeoutId;

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
    }, 300); // Adjust delay duration as needed
}

// Clear timeout to prevent hiding dropdown if mouse re-enters quickly
function clearHideProfileDropdown() {
    clearTimeout(timeoutId);
}

// Add event listeners
document.addEventListener('DOMContentLoaded', () => {
    const profile = document.querySelector('.profile');
    const profileDropdown = document.getElementById('profile-dropdown');

    // Show profile dropdown on mouseover
    profile.addEventListener('mouseover', showProfileDropdown);
    profile.addEventListener('mouseover', clearHideProfileDropdown);

    // Hide profile dropdown on mouseout with delay
    profile.addEventListener('mouseleave', hideProfileDropdown);
    profileDropdown.addEventListener('mouseleave', hideProfileDropdown);

    // Clear timeout if mouse re-enters profile area quickly
    profileDropdown.addEventListener('mouseover', clearHideProfileDropdown);
    profileDropdown.addEventListener('mouseover', showProfileDropdown);
});

var seconds = 0;
var minutes = 0;
var hours = 0;

// Function to update the timer display
function updateTimer() {
    seconds++;
    if (seconds >= 60) {
        seconds = 0;
        minutes++;
        if (minutes >= 60) {
            minutes = 0;
            hours++;
        }
    }
    document.getElementById('<%= lblTimer.ClientID %>').innerHTML = formatTime(hours) + ":" + formatTime(minutes) + ":" + formatTime(seconds);
}

// Function to add leading zero to single-digit numbers
function formatTime(time) {
    return time < 10 ? "0" + time : time;
}

// Update timer every second
window.setInterval(updateTimer, 1000);
