// JavaScript source code
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

// By default, show the 'students' content
document.addEventListener('DOMContentLoaded', () => {
    showContent('parents-kids');
});