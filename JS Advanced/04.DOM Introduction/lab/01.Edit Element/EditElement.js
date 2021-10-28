function editElement(ref, match, replace) {
    const element = ref.textContent;
    const matcher = new RegExp(match, 'g');
    const edit = element.replace(matcher, replace);
    ref.textContent = edit
}