// https://stackoverflow.com/a/73295995/10725664
async function fetchRetry(input: string) {
    let remainingRetries = 10;
    while (remainingRetries > 0) {
        try {
            return await fetch(input);
        } catch (error) { }

        console.log("fetchRetry failed");
        await new Promise(resolve => setTimeout(resolve, 200));
        console.log("fetchRetry retrying");

        remainingRetries--;
    }

    throw new Error(`Too many retries`);
}

export { fetchRetry };